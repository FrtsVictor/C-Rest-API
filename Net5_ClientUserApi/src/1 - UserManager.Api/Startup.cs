using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using UserManager.Api.ViewModels;
using UserManager.Domain.Entities;
using UserManager.Infra.Context;
using UserManager.Infra.Interfaces;
using UserManager.Infra.Repositories;
using UserManager.Services.DTO;
using UserManager.Services.Interfaces;
using UserManager.Services.Services;

namespace UserManager.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region AutoMapper
            //cria mapa entre user e user dto
            var autoMapperConfig = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<User, UserDTO>().ReverseMap(); //mapear pros dois lados
                configuration.CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());
            #endregion

            services.AddDbContext<UserManagerContext>(options => options.UseNpgsql(Configuration.GetConnectionString("UserManagerContext")));

            #region  DI
            //scoped adiciona uma instancia unica por requisição
            //transient uma instancia nova em cada ponto do codigo, uma instancia por requisição
            // singleton uma só pra toda aplicação
            //onde eu pedir IUserService, vai devolver uma instancia de UserService, por ex qd passo no construtor
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserManager.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserManager.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

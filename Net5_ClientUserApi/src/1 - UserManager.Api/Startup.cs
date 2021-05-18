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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManager.Api.Token;
using System;

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
            
            #region  Jwt

            var secretKey = Configuration["Jwt:Key"];

            services.AddAuthentication(x =>  //adiciono autenticacao na api
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters  //token vai validar os parametros
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)), //chave q pego no app settings
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            
            #endregion

            
            #region AutoMapper
            //cria mapa entre user e user dto
            var autoMapperConfig = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<User, UserDTO>().ReverseMap(); //mapear pros dois lados
                configuration.CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());
            #endregion

           

            #region  DI
            //scoped adiciona uma instancia unica por requisição
            //transient uma instancia nova em cada ponto do codigo, uma instancia por requisição
            // singleton uma só pra toda aplicação
            //onde eu pedir IUserService, vai devolver uma instancia de UserService, por ex qd passo no construtor
            //services.AddSingleton(a => Configuration);
            services.AddDbContext<UserManagerContext>(options => options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=UserAPI;User Id=postgres;Password=123321"));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            #endregion

            services.AddControllers();
           
             #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Users API",
                    Version = "v1",
                    Description = "Creating C# Api to learn DDD and C#",
                    Contact = new OpenApiContact
                    {
                        Email = "victofreitas.job@gmail.com",
                        Name = "Victor Freitas",
                        Url = new Uri("https://github.com/FrtsVictor")
                    },
                });
                
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "You'll need use the <TOKEN>",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });
            });

            #endregion

            #region Cryptography

            // services.AddRijndaelCryptography(Configuration["Cryptography"]);

            #endregion
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

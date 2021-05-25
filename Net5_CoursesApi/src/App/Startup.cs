using System;
using System.Text;
using App.Models.Users;
using App.Services;
using App.Token;
using AutoMapper;
using Courses.Models.Users;
using Infra.Context;
using Infra.Entities;
using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Net5_CoursesApi.Models.Users;
using Net5_CoursesApi.Token;

namespace Courses
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
             services.AddControllers()
            .ConfigureApiBehaviorOptions( options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            #region mapper
            var autoMapperConfig = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<RegisterViewModelInput, User>().ReverseMap(); 
                configuration.CreateMap<LoginViewModelInput, User>().ReverseMap();
                configuration.CreateMap<UpdateUserViewModel, User>().ReverseMap();
                configuration.CreateMap<User, UserViewModelOutput>().ReverseMap();
            });
            services.AddSingleton(autoMapperConfig.CreateMapper());

            #endregion

            #region context
            services.AddDbContext<CourseDbContext>(options => 
            {
                options.UseNpgsql(Configuration.GetConnectionString("Npg"));
            });
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            #endregion

            #region JWT

            var secret = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtConfigurations:Secret").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false; //will not use https
                x.SaveToken = true; //pra ficar no cache
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, 
                    IssuerSigningKey = new SymmetricSecurityKey(secret), 
                    ValidateIssuer = false,
                    ValidateAudience = false // local token, only on this api
                };
            });

            #endregion

            #region swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Courses", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    },
                });
            });

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI( c =>
                {
                     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Courses v1");
                     c.RoutePrefix = string.Empty;
                });
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

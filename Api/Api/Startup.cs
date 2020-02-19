using Api.ViewModels;
using AutoMapper;
using Core.DTO;
using Core.Entities;
using Core.Options;
using Core.Repositories;
using Core.Services;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace Api
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
            ConfigureJwtAuthService(services);
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DefaultContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IHotelsRepository, HotelsRepository>();
            services.AddScoped<IHotelsService, HotelsService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IRefreshTokensRepository, RefreshTokensRepository>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo() { Title = "Booking Machine", Version = "V1" });
            });

            var mappingConfiguration = new MapperConfiguration(c =>
            {
                c.CreateMap<HotelDTO, HotelEntity>().ReverseMap();
                c.CreateMap<HotelDTO, HotelViewModel>().ReverseMap();
                c.CreateMap<UserDTO, UserEntity>().ReverseMap();
                c.CreateMap<UserDTO, UserViewModel>().ReverseMap();
                c.CreateMap<LoginViewModel, LoginDTO>();
            });
            var mapper = mappingConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddControllers();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("swagger/v1/swagger.json", "Swagger V1"));

            app.UseHttpsRedirection();

            app.UseCors(builder => builder.AllowAnyOrigin());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureJwtAuthService(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.Issuer,
                    ValidateAudience = true,
                    ValidAudience = AuthOptions.Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true
                };
            });
            services.AddAuthorization();
        }
    }
}

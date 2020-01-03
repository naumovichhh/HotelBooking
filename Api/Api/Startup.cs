﻿using Api.ViewModels;
using AutoMapper;
using Core.DTO;
using Core.Entities;
using Core.Repositories;
using Core.Services;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddAuthorization();
            services.AddAuthentication();
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DefaultContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IHotelsRepository, HotelsRepository>();
            services.AddScoped<IHotelsService, HotelsService>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo() { Title = "Booking Machine", Version = "V1" });
            });

            var mappingConfiguration = new MapperConfiguration(c =>
            {
                c.CreateMap<HotelDTO, HotelEntity>().ReverseMap();
                c.CreateMap<HotelDTO, HotelViewModel>().ReverseMap();
            });
            var mapper = mappingConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddControllers();
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

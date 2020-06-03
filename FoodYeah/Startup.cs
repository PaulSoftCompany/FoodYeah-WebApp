using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FoodYeah.Persistence;
using FoodYeah.Service;
using AutoMapper;
using FoodYeah.Service.Impl;
using FoodYeah.Model;
using Microsoft.OpenApi.Models;

namespace FoodYeah
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


            //Para utilizar Swagger
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api FoodYeah", Version = "v1" });
            
            });

            // Para conectarse con Postgre:
            //
            services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                                  });
            }); 

            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(
               opts => opts.UseNpgsql(Configuration.GetConnectionString("AnotherConnection"))
            );

            // Para conectarse con SQL:
            //
            // services.AddDbContext<ApplicationDbContext>(
            //     opts => opts.UseSqlServer(Configuration.GetConnectionString("SQLConnection"))
            // );
            
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddTransient<CustomerService, CustomerServiceImpl>();
            services.AddTransient<ProductService, ProductServiceImpl>();
            services.AddTransient<OrderService, OrderServiceImpl>();
            services.AddTransient<CardService, CardServiceImpl>();            
            services.AddTransient<Product_CategoryService, Product_CategoryServiceImpl>();    
            services.AddTransient<Customer_CategoryService, Customer_CategoryServiceImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => {

                c.SwaggerEndpoint("/swagger/v1/swagger.json","API FOOD YEAH");  
            }
            );


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("MyAllowSpecificOrigins");
            app.UseAuthorization();
         

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           
        }
    }
}

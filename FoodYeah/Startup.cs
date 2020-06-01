using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FoodYeah.Persistence;
using FoodYeah.Service;
using AutoMapper;
using FoodYeah.Service.Impl;

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
            // Para conectarse con Postgre:
            //
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(
               opts => opts.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

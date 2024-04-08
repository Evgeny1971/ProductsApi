using ProductsApiManagement.BusinessLayer.Interfaces;
using ProductsApiManagement.BusinessLayer.Services;
using ProductsApiManagement.BusinessLayer.Services.Repository;
using ProductsApiManagement.DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApiManagement
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
                services.AddDbContext<ProductsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));

                services.AddSwaggerGen();
                services.AddControllers();
                services.AddHttpClient();

                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                // Configure connection string from appsettings.json
                string connectionString = Configuration.GetConnectionString("ConnStr");
                // Register ProductsDbAdoAccessor with dependency injection
                services.AddScoped<ProductsDbAdoAccessor>(provider =>
                new ProductsDbAdoAccessor(connectionString));

                services.AddScoped<IProductsApiRepository, ProductsApiRepository>();
                services.AddScoped<IProductsApiService, ProductsApiService>();

                services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.AllowAnyOrigin()
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                    });
                });
            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                app.UseStaticFiles();
                app.UseCors();
                app.UseHttpsRedirection();
                app.UseRouting();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
                });
                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }
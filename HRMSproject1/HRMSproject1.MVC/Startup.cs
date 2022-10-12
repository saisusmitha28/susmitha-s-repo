using HRMSproject1.Business.Interfaces;
using HRMSproject1.Business;
using HRMSproject1.Repository.Interfaces;
using HRMSproject1.Repository.Models;
using HRMSproject1.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRMSproject1.Utilities;

namespace HRMSproject1.MVC
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
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
           
            services.AddDbContext<SnadDataContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<MyContext>(options => options.UseSqlServer(connectionString));

            services.AddControllersWithViews();

            services.AddTransient<IEmployeeBusiness, EmployeeBusiness>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();


            services.AddAutoMapper(typeof(AutoMapperConfig));
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

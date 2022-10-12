using HRMSproject1.Business.Interfaces;
using HRMSproject1.Business;
using HRMSproject1.Repository.Interfaces;
using HRMSproject1.Repository.Models;
using HRMSproject1.Repository;
using HRMSproject1.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace HRMSproject1.API
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

            services.AddControllers();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<SnadDataContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<MyContext>(options => options.UseSqlServer(connectionString));

            services.AddControllersWithViews();

            services.AddTransient<IEmployeeBusiness, EmployeeBusiness>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<IDepartmentBusiness, DepartmentBusiness>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();

            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRMSproject1.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRMSproject1.API v1"));
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

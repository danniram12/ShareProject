using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Interface;
using DAL.Repository;
using DAL.Service;
using DAL.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using DAL.Validator;
using FluentValidation;
using FormHelper;

namespace WebApp
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
            services.AddControllersWithViews();
            services.AddDbContext<Context>(c => c.UseSqlServer(Configuration.GetConnectionString("DbConn")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddControllersWithViews().AddFormHelper();
            services.AddControllersWithViews().AddFluentValidation();
            services.AddTransient<IValidator<Employee>, EmployeeValidator>();
            services.AddTransient<IValidator<Company>, CompanyValidator>();
            //services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EmployeeValidator>());
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
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

using Bank.App.Webb.Data.Context;
using Bank.App.Webb.Data.Interfaces;
using Bank.App.Webb.Data.Repositories;
using Bank.App.Webb.Data.UnitOfWork;
using Bank.App.Webb.Mapping;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Webb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //opt BankContext deki Optiions yerine geçicek
            services.AddDbContext<BankContext>(opt =>
            {
                opt.UseSqlServer("server=DESKTOP-493DFJA\\SQLEXPRESS;database=EfBankProjeDB;integrated security=true");
            });
          
           // services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAccountMapper, AccountMapper>();
           // services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserMapper, UserMapper>();

            services.AddScoped<IUow, UnitOfWork>();
            //IApplicationUserRepository gördüðün zaman AppliccationUserRepository örneðini bana ver
           // services.AddScoped<IApplicationUserRepository, AppliccationUserRepository>();
            
            services.AddControllersWithViews();
            //services.AddSession();
            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //                   .RequireAuthenticatedUser()
            //                   .Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //});
            //services.AddMvc();
            //services.AddAuthentication(
            //    CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(x =>
            //    {
            //        x.LoginPath = "/Login/Login";
            //    });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            
            app.UseStaticFiles(
                new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/node_modules"
            } );
            //app.UseAuthentication();
            //app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}

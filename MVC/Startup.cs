using BogusService;
using BogusService.Fakers;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Models;
using Models.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVC
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
            services.AddControllersWithViews()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(x => x.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(Program)))
                .AddFluentValidation(/*x => x.RegisterValidatorsFromAssemblyContaining<UserValidator>()*/);

            services.AddTransient<IValidator<User>, UserValidator>();

            services.AddSingleton<Service<User>>(x => new Service<User>(new UserFaker(), 5));

            services.AddLocalization(x => x.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(x =>
            {
                x.SetDefaultCulture("en-us");
                x.AddSupportedCultures("en-us", "pl");
                x.AddSupportedUICultures("en-us", "pl");
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login";
                    x.LogoutPath = "/Login/Logout";
                    x.AccessDeniedPath = "/";
                    x.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                });
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

            app.UseRequestLocalization();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseStaticFiles(new StaticFileOptions
            {
                //using Microsoft.Extensions.FileProviders;
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Downloads")),
                RequestPath = "/pliki",
                //using Microsoft.AspNetCore.Http;
                OnPrepareResponse = x => x.Context.Response.Headers.Append("Cache-Control", "public, max-age=60000")
            });
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Downloads")),
                RequestPath = "/pliki"
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "welcome",
                    pattern: "{controller}/{action=Index}/{name}/{id?}");
            });
        }
    }
}

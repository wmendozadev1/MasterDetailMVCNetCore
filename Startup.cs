//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using TestMVCNetCore.Context;
//using TestMVCNetCore.CustomRepository;
//using TestMVCNetCore.Interfaces;

using TestMVCNetCore.Context;
using TestMVCNetCore.CustomRepository;
using TestMVCNetCore.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


using Microsoft.Extensions.Logging;


namespace TestMVCNetCore
{
    public class Startup
    {
        //public Startup(IConfiguration configuration, IWebHostEnvironment env)
        //{
        //    Configuration = configuration;
        //    environment = env;
        //    var builder = new ConfigurationBuilder()
        //    .SetBasePath(env.ContentRootPath)
        //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        //    .AddEnvironmentVariables();
        //    Configuration = builder.Build();
        //}

        //public IConfiguration Configuration { get; }
        //public IWebHostEnvironment environment;

        //// This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    //services.AddDbContext<TestMVCNetCoreContext>(options =>
        //    //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        //    services.AddDbContext<TestMVCNetCoreContext>(options =>
        //    {
        //        options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
        //        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //    }
        //    );

        //    services.AddControllersWithViews();
        //}

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }
        //    else
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //        app.UseHsts();
        //    }
        //    app.UseHttpsRedirection();
        //    app.UseStaticFiles();

        //    app.UseRouting();

        //    app.UseAuthorization();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllerRoute(
        //            name: "default",
        //            pattern: "{controller=Home}/{action=Index}/{id?}");
        //    });
        //}




        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            environment = env;
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment environment;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();//para que funcione el alert
            services.AddSession();


            services.AddScoped<ICompany, CompanyRepo>();
            services.AddScoped<IUserCompany, UserCompanyRepo>();
    

            services.AddDbContext<TestMVCNetCoreContext>(options =>
            {
                options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }

            );

            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<TestMVCNetCoreContext>()
               .AddDefaultTokenProviders();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSession(options =>
            {
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.IsEssential = true;

                options.IdleTimeout = TimeSpan.FromMinutes(10);//You can set Time   
            });

            services.AddDistributedMemoryCache();
       
            services.AddControllers()
            .AddJsonOptions(options =>
               options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.ConfigureApplicationCookie(options =>
               options.AccessDeniedPath = new PathString("/Account/AccessDenied")
                );

            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => options.LoginPath = "/Account/Login");


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {


            

            app.UseDeveloperExceptionPage();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();
            app.UseSession();
            app.UseCors();
            app.UseAuthentication();

            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapRazorPages();
            });

            app.Use((context, next) => {
                context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                return next.Invoke();
            });


        }




    }
}

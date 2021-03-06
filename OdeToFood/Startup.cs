﻿using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Routing;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using OdeToFood.Entities;
using OdeToFood.Services;

namespace OdeToFood
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework()
                    .AddSqlServer()
                    .AddDbContext<OdeToFoodDbContext>(options => options.UseSqlServer(Configuration["database:connection"]));
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<OdeToFoodDbContext>();
            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IGreeter greeter, IHostingEnvironment environment, IApplicationEnvironment appEnvironment)
        {
            app.UseIISPlatformHandler();
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRuntimeInfoPage();
            //app.UseFileServer();
            app.UseNodeModules(appEnvironment);
            app.UseIdentity();
            app.UseMvc(ConfigureRoutes);
            //app.UseMvcWithDefaultRoute();
            //app.UseWelcomePage();
            app.Run(async (context) =>
            {
                var greeting = greeter.GetGreeting();
                await context.Response.WriteAsync(greeting);
            });
        }
        
        // convention based routing
        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index
            // ? optional
            // default to Home
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

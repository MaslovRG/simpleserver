﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration; 
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis; 

namespace SimpleServer
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        /// <summary>
        /// Переменная окружения
        /// </summary>
        private readonly IHostingEnvironment _env; 

        /// <summary>
        /// Конфигирурем сервер
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsetings.json", false, true)
                .AddEnvironmentVariables(); 
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // сжатие            
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });

            services.AddMvc(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseResponseCompression();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    "operation",
                    "{controller}/{action}/{one}/{two}"); 
            });
        }
    }
}

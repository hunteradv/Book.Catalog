using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<ICatalog, Catalog>();
            //services.AddTransient<IReport, Report>();

            //services.AddScoped<ICatalog, Catalog>();
            //services.AddScoped<IReport, Report>();

            var catalog = new Catalog();
            services.AddSingleton<ICatalog>(catalog);
            services.AddSingleton<IReport>(new Report(catalog));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }           

            var catalog = serviceProvider.GetService<ICatalog>();
            var report = serviceProvider.GetService<IReport>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await report.Print(context);                  
                });
            });
        }
    }
}

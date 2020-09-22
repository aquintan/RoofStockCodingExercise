using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RoofStock.CodingExercise.UI.Contracts;
using RoofStock.CodingExercise.UI.Infrastructure.Configs;
using RoofStock.CodingExercise.UI.Services;

namespace RoofStock.CodingExercise.UI
{
    using Models;

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
            var policyConfigs = new HttpClientPolicyConfiguration();
            Configuration.Bind("HttpClientPolicies", policyConfigs);

            services.AddHttpClient<IApiService, ApiService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["ApiResourceBaseUrls:Api"]);
                client.DefaultRequestHeaders.Accept.Clear();
            });

            services.AddControllersWithViews();
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
                    pattern: "{controller=Properties}/{action=Index}/{id?}");
            });
        }
    }
}
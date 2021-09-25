using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWorld.API.Models;
using MadWorld.DataLayer.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MadWorld.API
{
    public class Startup
    {
        private StartupSettings Settings;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Settings = Configuration.Get<StartupSettings>();

            services.AddApplicationInsightsTelemetry();

            services.AddControllers();

            SetupDatabases(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void SetupDatabases(IServiceCollection services)
        {
            if (Environment.IsDevelopment() && (!Settings?.ForceUseMSSQL ?? true))
            {
                services.AddDbContext<MadWorldContextDev>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("MadWorldDatabase"), b => b.MigrationsAssembly("MadWorld.API")));
            }
            else if (Environment.IsProduction() || (Settings?.ForceUseMSSQL ?? false))
            {
                services.AddDbContext<MadWorldContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MadWorldDatabase"), b => b.MigrationsAssembly("MadWorld.API")));
            }
            else
            {
                throw new Exception("No Database selected.");
            }
        }
    }
}

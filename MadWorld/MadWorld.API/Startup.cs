using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWorld.API.Models;
using MadWorld.Business.Manager;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.DataLayer.Database;
using MadWorld.DataLayer.Database.Queries;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
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
        private readonly string AllowedOriginsAPI = "AllowedCalls";

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

            SetAPI(services);
            SetupDatabases(services);

            services.AddDefaultIdentity<IdentityUser>(options =>
                options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MadWorldContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<IdentityUser, MadWorldContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowedOriginsAPI,
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:5001", "https://www.mad-world.nl", "https://mad-world.nl")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
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

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(AllowedOriginsAPI);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void SetAPI(IServiceCollection services)
        {
            // Business
            services.AddScoped<IResumeManager, ResumeManager>();

            // Datalayer
            services.AddScoped<IResumeQueries, ResumeQueries>();
        }

        private void SetupDatabases(IServiceCollection services)
        { 
            if (Settings?.ForgePostgresMigration ?? false)
            {
                services.AddDbContext<MadWorldContextDev>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("MadWorldDatabase"), b => b.MigrationsAssembly("MadWorld.API")));

                return;
            }

            if (Settings?.ForgeMsSqlMigration ?? false)
            {
                services.AddDbContext<MadWorldContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MadWorldDatabase"), b => b.MigrationsAssembly("MadWorld.API")));

                return;
            }

            if (Environment.IsDevelopment())
            {
                services.AddDbContext<MadWorldContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("MadWorldDatabase"), b => b.MigrationsAssembly("MadWorld.API")));
            }
            else if (Environment.IsProduction())
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

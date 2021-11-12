using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWorld.API.Models;
using MadWorld.API.SignalR;
using MadWorld.API.SignalR.Interfaces;
using MadWorld.Business.Manager;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.DataLayer.AzureBlob;
using MadWorld.DataLayer.AzureBlob.Interfaces;
using MadWorld.DataLayer.Database;
using MadWorld.DataLayer.Database.Queries;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Microsoft.Identity.Web;


namespace MadWorld.API
{
    public class Startup
    {
        private readonly string AllowedOriginsAPI = "AllowedCalls";

        private AzureSettings AzureSettings;
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
            Settings = Configuration.GetSection(nameof(StartupSettings)).Get<StartupSettings>();
            AzureSettings = Configuration.GetSection(nameof(AzureSettings)).Get<AzureSettings>();

            services.AddApplicationInsightsTelemetry();

            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAdB2C"));

            services.Configure<JwtBearerOptions>(
            JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters.NameClaimType = "name";
            });

            SetAPI(services);
            SetupDatabases(services);

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

            services.AddSignalR();
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

            app.UseCors(AllowedOriginsAPI);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<GeneralHub>("/GeneralHub");
            });
        }

        private void SetAPI(IServiceCollection services)
        {
            // SignalR
            services.AddScoped<IGeneralHubManager, GeneralHubManager>();

            // Business
            services.AddScoped<IAuthorizationManager, AuthorizationManager>();
            services.AddScoped<IResumeManager, ResumeManager>();
            services.AddScoped<ISecurityReportManager, SecurityReportManager>();
            services.AddScoped<IUserManager, UserManager>();

            // Datalayer
            services.AddScoped<IBlobManager, BlobManager>(_ => {
                return new BlobManager(Configuration.GetConnectionString("MadWorldBlobs"), AzureSettings.ContainerName);
            });

            services.AddScoped<IAuthorizationQueries, AuthorizationQueries>();
            services.AddScoped<IBlobTableQueries, BlobTableQueries>();
            services.AddScoped<IResumeQueries, ResumeQueries>();
            services.AddScoped<ISecurityReportQueries, SecurityReportQueries>();
            services.AddScoped<IStorageManager, StorageManager>();
            services.AddScoped<IUserManagmentQueries, UserManagmentQueries>();
        }

        private void SetupDatabases(IServiceCollection services)
        { 
            if (Settings?.ForgePostgresMigration ?? false)
            {
                services.AddDbContext<MadWorldContextDev>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("MadWorldDatabase"), b => b.MigrationsAssembly("MadWorld.API")));
                services.AddScoped<MadWorldContext, MadWorldContextDev>();

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

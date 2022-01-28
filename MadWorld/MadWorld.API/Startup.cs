using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MadWorld.API.Extenstions;
using MadWorld.API.Models;
using MadWorld.API.SignalR;
using MadWorld.API.SignalR.Interfaces;
using MadWorld.Business.Manager;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.Business.Mapper;
using MadWorld.Business.Mapper.Interfaces;
using MadWorld.Business.Models;
using MadWorld.Business.Services;
using MadWorld.Business.Services.Interfaces;
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
using Microsoft.AspNetCore.Mvc.Versioning;
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
        private ApplicationSettings ApplicationSettings;
        private ApplicationUrls ApplicationUrls;
        private StartupSettings Settings;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            AzureSettings = new();
            ApplicationSettings = new();
            ApplicationUrls = new();
            Settings = new();
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Settings = Configuration.GetSection(nameof(StartupSettings)).Get<StartupSettings>();
            AzureSettings = Configuration.GetSection(nameof(AzureSettings)).Get<AzureSettings>();
            ApplicationSettings = Configuration.GetSection(nameof(ApplicationSettings)).Get<ApplicationSettings>();
            ApplicationUrls = Configuration.GetSection(nameof(ApplicationUrls)).Get<ApplicationUrls>();

            services.AddApplicationInsightsTelemetry();

            services.AddControllers();
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = ApiVersion.Default;
                //Accept : application/json; version=1.0
                options.ApiVersionReader = new MediaTypeApiVersionReader("version");
                //API-Version : 1.0
                //options.ApiVersionReader = new HeaderApiVersionReader("API-Version");
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAdB2C"));

            services.Configure<JwtBearerOptions>(
                JwtBearerDefaults.AuthenticationScheme,
                options => { options.TokenValidationParameters.NameClaimType = "name"; });

            services.AddMadWorldAPI(settings =>
            {
                settings.ApplicationUrls = ApplicationUrls;
                settings.AzureSettings = AzureSettings;
                settings.BlobConnectionString = Configuration.GetConnectionString("MadWorldBlobs");
            });

            services.AddMadWorldDatabases(settings =>
            {
                settings.StartupSettings = Settings;
                settings.ConnectionString = Configuration.GetConnectionString("MadWorldDatabase");
                settings.IsDevelopment = Environment.IsDevelopment();
                settings.IsProduction = Environment.IsProduction();
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowedOriginsAPI,
                    builder =>
                    {
                        builder.WithOrigins(ApplicationSettings.CorsUrls)
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
            app.UseSecurityHeaders();

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
    }
}

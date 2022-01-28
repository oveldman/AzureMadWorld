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
using Microsoft.EntityFrameworkCore;

namespace MadWorld.API.Extenstions;

public static class IServiceCollectionExtensions
{
    private const string AssemblyNameAPI = "MadWorld.API";
    
    public static IServiceCollection AddMadWorldAPI(this IServiceCollection services, Action<MadWorldSettings> settings)
    {
        var madWorldSettings = new MadWorldSettings();
        settings.Invoke(madWorldSettings);
        
        // Settings
        services.AddScoped<ApplicationUrls>(_ => madWorldSettings.ApplicationUrls);

        // SignalR
        services.AddScoped<IGeneralHubManager, GeneralHubManager>();

        // Businesses
        services.AddScoped<IAuthorizationManager, AuthorizationManager>();
        services.AddScoped<IIpfsManager, IpfsManager>();
        services.AddScoped<IIpfsMapperManager, IpfsMapperManager>();
        services.AddScoped<IResumeManager, ResumeManager>();
        services.AddScoped<ISecurityReportManager, SecurityReportManager>();
        services.AddScoped<IUserManager, UserManager>();
        services.AddScoped<IVpsWebServices, VpsWebServices>();

        // Datalayers
        services.AddScoped<IBlobManager, BlobManager>(_ => {
            return new BlobManager(madWorldSettings.BlobConnectionString, madWorldSettings.AzureSettings.ContainerName);
        });

        services.AddScoped<IAuthorizationQueries, AuthorizationQueries>();
        services.AddScoped<IBlobTableQueries, BlobTableQueries>();
        services.AddScoped<IIpfsQueries, IpfsQueries>();
        services.AddScoped<IResumeQueries, ResumeQueries>();
        services.AddScoped<ISecurityReportQueries, SecurityReportQueries>();
        services.AddScoped<IStorageManager, StorageManager>();
        services.AddScoped<IUserManagmentQueries, UserManagmentQueries>();

        // Extras
        services.AddScoped<HttpClient>();
        
        return services;
    }

    public static IServiceCollection AddMadWorldDatabases(this IServiceCollection services, Action<DataBaseSettings> settings)
    {
        var dataBaseSettings = new DataBaseSettings();
        settings.Invoke(dataBaseSettings);
        
        if (dataBaseSettings.StartupSettings?.ForgePostgresMigration ?? false)
        {
            services.AddDbContext<MadWorldContextDev>(options =>
                options.UseNpgsql(dataBaseSettings.ConnectionString, b => b.MigrationsAssembly(AssemblyNameAPI)));
            services.AddScoped<MadWorldContext, MadWorldContextDev>();

            return services;
        }

        if (dataBaseSettings.StartupSettings?.ForgeMsSqlMigration ?? false)
        {
            services.AddDbContext<MadWorldContext>(options =>
                options.UseSqlServer(dataBaseSettings.ConnectionString, b => b.MigrationsAssembly(AssemblyNameAPI)));

            return services;
        }

        if (dataBaseSettings.IsDevelopment)
        {
            services.AddDbContext<MadWorldContext>(options =>
                options.UseNpgsql(dataBaseSettings.ConnectionString, b => b.MigrationsAssembly(AssemblyNameAPI)));
        }
        else if (dataBaseSettings.IsProduction)
        {
            services.AddDbContext<MadWorldContext>(optionsBuilder => {
                optionsBuilder.UseSqlServer(dataBaseSettings.ConnectionString, options => {
                    options.MigrationsAssembly(AssemblyNameAPI);
                    options.EnableRetryOnFailure(maxRetryCount: 10);
                });
            });
        }
        else
        {
            throw new Exception("No Database selected.");
        }
        
        return services;
    }
}
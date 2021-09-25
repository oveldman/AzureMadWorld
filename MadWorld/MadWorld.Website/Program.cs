using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorApplicationInsights;
using BlazorDownloadFile;
using MadWorld.Website.Settings;
using MadWorld.Website.Services.Interfaces;
using MadWorld.Website.Services.Info;

namespace MadWorld.Website
{
    public class Program
    {
        private static string InstrumentationKey;

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddHttpClient(ApiUrls.MadWorldApi, client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            SetApplicationSettings(builder.Configuration);
            AddExternPackages(builder.Services);
            AddMadWorldClassesToScoped(builder.Services);

            await builder.Build().RunAsync();
        }

        private static void AddExternPackages(IServiceCollection services)
        {
            services.AddBlazorApplicationInsights(async applicationInsights =>
            {
                await applicationInsights.SetInstrumentationKey(InstrumentationKey);
                await applicationInsights.LoadAppInsights();
            });

            services.AddBlazorDownloadFile();
        }

        private static void AddMadWorldClassesToScoped(IServiceCollection services)
        {
            // Services
            services.AddScoped<IResumeService, ResumeService>();
        }

        private static void SetApplicationSettings(WebAssemblyHostConfiguration configuration)
        {
            InstrumentationKey = configuration["Azure:InstrumentationKey"];
        }
    }
}

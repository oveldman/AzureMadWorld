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
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MadWorld.Website.Services.Support;
using Microsoft.AspNetCore.Components.Authorization;
using MadWorld.Website.Factory;
using System.Security.Claims;
using MadWorld.Website.Services.Authorization;
using BlazorTable;
using MadWorld.Website.Services.Admin.Interfaces;
using MadWorld.Website.Services.Admin;
using Microsoft.AspNetCore.Components.Web;
using MadWorld.Website.State.Interface;
using MadWorld.Website.State;

namespace MadWorld.Website
{
    public class Program
    {
        private static string InstrumentationKey;

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddHttpClient(ApiUrls.MadWorldApiAnonymous, client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            builder.Services.AddHttpClient(ApiUrls.MadWorldApi, client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }).AddHttpMessageHandler(sp =>
            {
                var handler = sp.GetService<AuthorizationMessageHandler>()
                    .ConfigureHandler(
                        authorizedUrls: new[] { builder.Configuration["ApiUrl"] }, //<--- The URI used by the Server project.
                        scopes: new[] { "https://nlMadWorld.onmicrosoft.com/36e6692b-2795-4ecd-ab76-3ff2f55373e7/Api.ReadWrite" });
                return handler;
            });

            builder.Services.AddScoped<DelegatingHandlerMW>();
            builder.Services.AddHttpClient(ApiUrls.MadWorldApiAuthorization, client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }).AddHttpMessageHandler<DelegatingHandlerMW>();


            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
                .CreateClient(ApiUrls.MadWorldApi));

            builder.Services.AddMsalAuthentication<RemoteAuthenticationState, RemoteUserAccountMW>(options =>
            {
                builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
                options.ProviderOptions.DefaultAccessTokenScopes.Add("openid");
                options.ProviderOptions.DefaultAccessTokenScopes.Add("offline_access");
                options.ProviderOptions.DefaultAccessTokenScopes.Add("https://nlMadWorld.onmicrosoft.com/36e6692b-2795-4ecd-ab76-3ff2f55373e7/Api.ReadWrite");
                options.UserOptions.RoleClaim = ClaimTypes.Role;
            }).AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, RemoteUserAccountMW, AccountClaimsPrincipalFactoryMW>();
            builder.Services.AddScoped<AuthenticationStateProvider, RemoteAuthenticationServiceMW>();

            SetApplicationSettings(builder.Configuration);
            AddExternPackages(builder);
            AddMadWorldClassesToScoped(builder.Services);

            await builder.Build().RunAsync();
        }

        private static void AddExternPackages(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddBlazorApplicationInsights(async applicationInsights =>
            {
                await applicationInsights.SetInstrumentationKey(InstrumentationKey);
                await applicationInsights.LoadAppInsights();
            });

            builder.Services.AddBlazorDownloadFile();
            builder.Services.AddBlazorTable();
        }

        private static void AddMadWorldClassesToScoped(IServiceCollection services)
        {
            // Services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IResumeService, ResumeService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IUserManagerService, UserManagerService>();

            // State
            services.AddScoped<IAuthenticationHandler, AuthenticationHandler>();
        }

        private static void SetApplicationSettings(WebAssemblyHostConfiguration configuration)
        {
            InstrumentationKey = configuration["Azure:InstrumentationKey"];
        }
    }
}

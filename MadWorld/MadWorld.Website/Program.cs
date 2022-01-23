using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
using Microsoft.AspNetCore.SignalR.Client;
using MadWorld.Website.Services.Tools;
using MadWorld.Website.JavascriptManager.Interfaces;
using MadWorld.Website.JavascriptManager;
using MadWorld.Shared.Client.Manager.Running.Interfaces;
using MadWorld.Shared.Client.Manager.Running;
using MadWorld.Shared.Common.DesignPattern.Iterator;
using MadWorld.Shared.Client.Models.Tools.Running;
using Blazored.LocalStorage;
using MadWorld.Website.Extension;
using BlazorApplicationInsights;

namespace MadWorld.Website
{
    public class Program
    {
        private static string ApiUrl;
        private static string ApiVersion;
        private static string InstrumentationKey;

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            SetApplicationSettings(builder.Configuration);

            builder.Services.AddHttpClient(ApiUrls.MadWorldApiAnonymous, client =>
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Add("Accept", $"application/json; version={ApiVersion}");
            }).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            builder.Services.AddHttpClient(ApiUrls.MadWorldApi, client =>
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Add("Accept", $"application/json; version={ApiVersion}");
            }).AddHttpMessageHandler(sp =>
            {
                var handler = sp.GetService<AuthorizationMessageHandler>()
                    .ConfigureHandler(
                        authorizedUrls: new[] { ApiUrl }, //<--- The URI used by the Server project.
                        scopes: new[] { "https://nlMadWorld.onmicrosoft.com/36e6692b-2795-4ecd-ab76-3ff2f55373e7/Api.ReadWrite" });
                return handler;
            });

            builder.Services.AddScoped<DelegatingHandlerMW>();
            builder.Services.AddHttpClient(ApiUrls.MadWorldApiAuthorization, client =>
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Add("Accept", $"application/json; version={ApiVersion}");
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

            AddExternPackages(builder);
            builder.Services.AddInternalClasses();

            await builder.Build().RunAsync();
        }

        private static void AddExternPackages(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddBlazorApplicationInsights(async applicationInsights =>
            {
                await applicationInsights.SetInstrumentationKey(InstrumentationKey);
                await applicationInsights.TrackPageView();
            });

            builder.Services.AddScoped<HubConnection>(_ =>
                    new HubConnectionBuilder()
                .WithUrl($"{ApiUrl}GeneralHub")
                .Build()
            );

            builder.Services.AddBlazorDownloadFile();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazorTable();
        }

        private static void SetApplicationSettings(WebAssemblyHostConfiguration configuration)
        {
            ApiUrl = configuration["ApiUrl"];
            ApiVersion = configuration["ApiVersion"];
            InstrumentationKey = configuration["Azure:InstrumentationKey"];
        }
    }
}

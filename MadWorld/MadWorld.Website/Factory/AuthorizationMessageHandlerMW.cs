using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace MadWorld.Website.Factory
{
    public class AuthorizationMessageHandlerMW : AuthorizationMessageHandler
    {
        public AuthorizationMessageHandlerMW(IAccessTokenProvider provider,
            NavigationManager navigationManager, DelegatingHandlerMW delegatingHandler)
            : base(provider, navigationManager)
        {
            this.InnerHandler = delegatingHandler;

            /*
            ConfigureHandler(
                authorizedUrls: new[] { "https://localhost:59761/" },
                scopes: new[] { "https://nlMadWorld.onmicrosoft.com/36e6692b-2795-4ecd-ab76-3ff2f55373e7/Api.ReadWrite" });
            */
        }

        //authorizedUrls: new[] { builder.Configuration["ApiUrl"] }, //<--- The URI used by the Server project.
    }
}


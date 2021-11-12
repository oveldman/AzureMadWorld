using System;
using MadWorld.Website.Factory;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Authentication.WebAssembly.Msal.Models;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace MadWorld.Website.State
{
    public class RemoteAuthenticationServiceMW : RemoteAuthenticationService<RemoteAuthenticationState, RemoteUserAccountMW, MsalProviderOptions>
    {
        public RemoteAuthenticationServiceMW(IJSRuntime ijsRuntime,
            IOptionsSnapshot<RemoteAuthenticationOptions<MsalProviderOptions>> options,
            NavigationManager navigation,
            AccountClaimsPrincipalFactory<RemoteUserAccountMW> factory
            ) : base(ijsRuntime, options, navigation, factory)
        {
        }

        public void Notify()
        {
            this.NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}


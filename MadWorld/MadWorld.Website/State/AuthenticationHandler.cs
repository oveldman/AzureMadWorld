using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MadWorld.Website.Factory;
using MadWorld.Website.Services.Interfaces;
using MadWorld.Website.State.Interface;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Authentication.WebAssembly.Msal.Models;

namespace MadWorld.Website.State
{
    public class AuthenticationHandler : IAuthenticationHandler
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IAccountService _accountService;

        public AuthenticationHandler(AuthenticationStateProvider authenticationStateProvider, IAccountService service)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _accountService = service;
        }

        public async Task<bool> ResetRoles()
        {
            AuthenticationState authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            ClaimsIdentity identity = authState?.User?.Identity as ClaimsIdentity;

            if (identity?.IsAuthenticated ?? false)
            {
                RemoveRoleClaims(identity);
                await UpdateWithNewRoles(identity);

                if (_authenticationStateProvider is RemoteAuthenticationServiceMW provider)
                {
                    provider.Notify();
                }
            }

            return true;
        }

        private void RemoveRoleClaims(ClaimsIdentity identity)
        {
            var roleClaims = identity.Claims.Where(c => c.Type == ClaimTypes.Role);

            foreach (Claim claim in roleClaims)
            {
                identity.RemoveClaim(claim);
            }
        }

        private async Task UpdateWithNewRoles(ClaimsIdentity identity)
        {
            List<string> roles = await _accountService.GetCurrentAccountRoles();
            foreach (string role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }
        }
    }
}


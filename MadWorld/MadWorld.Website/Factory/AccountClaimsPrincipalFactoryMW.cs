using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using MadWorld.Shared.Models.Authorization;
using MadWorld.Website.Services.Interfaces;
using MadWorld.Website.Settings;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

namespace MadWorld.Website.Factory
{
    public class AccountClaimsPrincipalFactoryMW : AccountClaimsPrincipalFactory<RemoteUserAccountMW>
    {
        private IAccessTokenProviderAccessor _accessor { get; }
        private IAccountService _service { get; }

        public AccountClaimsPrincipalFactoryMW(IAccessTokenProviderAccessor accessor, IAccountService service) : base(accessor)
        {
            _accessor = accessor;
            _service = service;
        }

        public async override ValueTask<ClaimsPrincipal> CreateUserAsync(RemoteUserAccountMW account,
            RemoteAuthenticationUserOptions options)
        {
            ClaimsPrincipal user = await base.CreateUserAsync(account, options);

            if (user.Identity.IsAuthenticated)
            {
                ClaimsIdentity claimsIdentity = (ClaimsIdentity)user.Identity;
                List<string> roles= await _service.GetCurrentAccountRoles();
                foreach (string role in roles)
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Adminstrator"));
            }

            return user;
        }
    }
}


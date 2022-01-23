using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MadWorld.Shared.Web.Models.Authorization;
using MadWorld.Website.Services.Interfaces;
using MadWorld.Website.Settings;

namespace MadWorld.Website.Services.Authorization
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _client;

        public AccountService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(ApiUrls.MadWorldApiAuthorization);
        }

        public async Task<List<string>> GetCurrentAccountRoles()
        {
            RolesResponse response = await _client.GetFromJsonAsync<RolesResponse>("Authorize/GetCurrentUserRols");
            return response.Roles;
        }
    }
}


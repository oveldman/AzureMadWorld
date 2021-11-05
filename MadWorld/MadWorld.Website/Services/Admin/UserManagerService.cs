using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MadWorld.Shared.Models.Admin;
using MadWorld.Website.Services.Admin.Interfaces;
using MadWorld.Website.Settings;

namespace MadWorld.Website.Services.Admin
{
    public class UserManagerService : IUserManagerService
    {
        private HttpClient _client;

        public UserManagerService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(ApiUrls.MadWorldApi);
        }

        public async Task<UsersResponse> GetUsers()
        {
            return await _client.GetFromJsonAsync<UsersResponse>($"Admin/User/GetUsers");
        }
    }
}


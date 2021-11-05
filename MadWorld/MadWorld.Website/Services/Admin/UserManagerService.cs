using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MadWorld.Shared.Models;
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

        public async Task<UserResponse> GetUser(string id)
        {
            return await _client.GetFromJsonAsync<UserResponse>($"Admin/User/GetUser?id={id}");
        }

        public async Task<UsersResponse> GetUsers()
        {
            return await _client.GetFromJsonAsync<UsersResponse>($"Admin/User/GetUsers");
        }

        public async Task<BaseResponse> SaveUser(UserDTO user)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync<UserDTO>($"Admin/User/UpdateUser", user);
            return await response.Content.ReadFromJsonAsync<BaseResponse>();
        }
    }
}


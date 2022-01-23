using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MadWorld.Shared.Web.Models;
using MadWorld.Shared.Web.Models.Admin.IPFS;
using MadWorld.Website.Services.Admin.Interfaces;
using MadWorld.Website.Settings;

namespace MadWorld.Website.Services.Admin
{
	public class IpfsManagerService : IIpfsManagerService
	{
        private HttpClient _client;

        public IpfsManagerService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(ApiUrls.MadWorldApi);
        }

        public async Task<BaseResponse> Delete(string id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"Admin/Ipfs/Delete?id={id}");
            return await response.Content.ReadFromJsonAsync<BaseResponse>();
        }

        public async Task<IpfsAdminDetailResponse> GetDetails(string id)
        {
            return await _client.GetFromJsonAsync<IpfsAdminDetailResponse>($"Admin/Ipfs/GetDetails?id={id}");
        }

        public async Task<BaseResponse> Save(IpfsAdminDTO file)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync<IpfsAdminDTO>($"Admin/Ipfs/Update", file);
            return await response.Content.ReadFromJsonAsync<BaseResponse>();
        }

        public async Task<IpfsAdminSearchResponse> Search()
        {
            return await _client.GetFromJsonAsync<IpfsAdminSearchResponse>($"Admin/Ipfs/Search");
        }
    }
}


using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MadWorld.Shared.Models.IPFS;
using MadWorld.Website.Services.Interfaces;
using MadWorld.Website.Settings;

namespace MadWorld.Website.Services.Tools
{
	public class IpfsService : IIpfsService
	{
        private HttpClient _client;

        public IpfsService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(ApiUrls.MadWorldApiAnonymous);
        }

        public async Task<IpfsDetailResponse> GetDetails(string hash)
        {
            return await _client.GetFromJsonAsync<IpfsDetailResponse>($"ipfs/getdetails?hash={hash}");
        }

        public async Task<IpfsSearchResponse> Search()
        {
            return await _client.GetFromJsonAsync<IpfsSearchResponse>($"ipfs/search");
        }
    }
}


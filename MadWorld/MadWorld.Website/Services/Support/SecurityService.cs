using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MadWorld.Shared.Models;
using MadWorld.Shared.Models.Pages.Support;
using MadWorld.Website.Services.Interfaces;
using MadWorld.Website.Settings;

namespace MadWorld.Website.Services.Support
{
    public class SecurityService : ISecurityService
    {
        private HttpClient _client;

        public SecurityService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(ApiUrls.MadWorldApiAnonymous);
        }

        public async Task<BaseResponse> SendReport(SecurityReportRequest request)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("support/reportsecurity", request);
            return await response.Content.ReadFromJsonAsync<BaseResponse>();
        }
    }
}

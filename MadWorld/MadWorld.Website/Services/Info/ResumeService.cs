using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MadWorld.Shared.Models.Pages;
using MadWorld.Website.Services.Interfaces;
using MadWorld.Website.Settings;

namespace MadWorld.Website.Services.Info
{
    public class ResumeService : IResumeService
    {
        private HttpClient _client;

        public ResumeService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(ApiUrls.MadWorldApiAnonymous);
        }

        public async Task<ResumeResponse> Get()
        {
            return await _client.GetFromJsonAsync<ResumeResponse>($"resume");
        }
    }
}

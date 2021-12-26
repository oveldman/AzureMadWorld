using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MadWorld.Business.Services.Models;

namespace MadWorld.Business.Services
{
	public class WebServices : IWebServices
	{
        private readonly string requestUrl = string.Empty;
        private readonly HttpClient _httpClient;
        
		public WebServices(string url)
		{
            requestUrl = url;
            _httpClient = new HttpClient();
		}

        public async Task<WebResult<Stream>> GetRequest(List<WebParameter> parameters)
        {
            WebResult<Stream> result = new();

            string fullUrl = CreateFullUrl(parameters);
            HttpResponseMessage response = await _httpClient.GetAsync(fullUrl, HttpCompletionOption.ResponseHeadersRead);

            result.HttpStatus = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                result.Body = response.Content.ReadAsStream();
            }

            return result;
        }

        private string CreateFullUrl(List<WebParameter> parameters)
        {
            string url = requestUrl;

            if (!parameters.Any())
            {
                return url;
            }

            if (parameters.Count() == 1 && parameters[0].Name.Equals("id", StringComparison.OrdinalIgnoreCase))
            {
               url = url.Last() == '/' ? url : $"{url}/";
               return url + parameters[0].Value;
            }

            url = $"{url}?";

            foreach (WebParameter parameter in parameters)
            {
                url += $"{parameter.Name}={parameter.Value}&";
            }

            url = url.Remove(url.Length);

            return url;
        }
    }
}


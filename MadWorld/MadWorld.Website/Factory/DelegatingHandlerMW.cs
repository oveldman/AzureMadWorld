using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorld.Website.Factory
{
    public class DelegatingHandlerMW : DelegatingHandler
    {
        IServiceProvider _provider;

        public DelegatingHandlerMW(IServiceProvider provider)
        {
            _provider = provider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, CancellationToken cancellationToken)
        {
            // AccessTokenProvider crashes when object is intinized.
            // Work around is get accessTokenProvider when needed.
            // Try remove this when dotnet 6 is out of beta.
            var tokenProvider = _provider.GetRequiredService<IAccessTokenProvider>();
            var accessTokenResult = await tokenProvider.RequestAccessToken();
            if (accessTokenResult.TryGetToken(out var token))
            {
                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
            }
            return await base.SendAsync(message, cancellationToken);
        }
    }
}


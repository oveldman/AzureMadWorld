using System;
using System.Net.Http;
using MadWorld.Console.Insight.Interfaces;
using Microsoft.Azure.ApplicationInsights.Query;
using Microsoft.Azure.ApplicationInsights.Query.Models;
using Microsoft.Rest;

namespace MadWorld.Console.Insight
{
    public class ApplicationInsightAPI : IApiManager
    {
        public ApplicationInsightAPI()
        {
        }

        public QueryResults GetErrorData()
        {
            var appId = "{appID}";
            var apiKey = "{ apiKey}";

            ServiceClientCredentials credentials = new ApiKeyClientCredentials(apiKey);

            // Instantiate a client with credentials
            var client = new ApplicationInsightsDataClient(credentials);

            // Execute a query with Application Insights application Id
            return client.Query.Execute(appId, "exceptions");
        }
    }
}

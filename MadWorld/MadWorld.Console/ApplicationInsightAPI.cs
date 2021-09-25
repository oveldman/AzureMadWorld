using System;
using System.Net.Http;
using Microsoft.Azure.ApplicationInsights.Query;
using Microsoft.Rest;

namespace MadWorld.Console
{
    public class ApplicationInsightAPI
    {
        public ApplicationInsightAPI()
        {
        }

        public static void GetData()
        {
            var appId = "{appID}";

            ServiceClientCredentials credentials = new ApiKeyClientCredentials("{ApiKey}");

            // Instantiate a client with credentials
            var client = new ApplicationInsightsDataClient(credentials);

            // Execute a query with Application Insights application Id
            var results = client.Query.Execute(appId, "exceptions");

            for (var i = 0; i < results.Tables[0].Rows.Count; i++)
            {
                // Do something with query results
                System.Console.WriteLine(String.Join("    ", results.Tables[0].Rows[i]));
            }
        }
    }
}

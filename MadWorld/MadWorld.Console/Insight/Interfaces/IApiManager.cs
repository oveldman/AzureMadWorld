using System;
using Microsoft.Azure.ApplicationInsights.Query.Models;

namespace MadWorld.Console.Insight.Interfaces
{
    public interface IApiManager
    {
        QueryResults GetErrorData();
    }
}

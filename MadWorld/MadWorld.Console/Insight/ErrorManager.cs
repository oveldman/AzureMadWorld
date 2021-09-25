using System;
using System.Collections.Generic;
using MadWorld.Console.Insight.Interfaces;
using MadWorld.Console.Insight.Models;
using Microsoft.Azure.ApplicationInsights.Query.Models;

namespace MadWorld.Console.Insight
{
    public class ErrorManager : IErrorManager
    {
        IApiManager _insightApi;

        public ErrorManager()
        {
            _insightApi = new ApplicationInsightAPI();
        }

        public List<Error> GetErrors()
        {
            List<Error> errors = new();

            QueryResults result = _insightApi.GetErrorData();
            ErrorHeaders headers = FindHeaders(result);
            var allRows = result.Tables[0].Rows;

            foreach (var row in allRows)
            {
                Error error = new();

                for (int i = 0; i < row.Count; i++)
                {
                    if (headers.ProblemId == i)
                    {
                        error.ProblemID = row[i].ToString();
                    }

                    if (headers.Message == i)
                    {
                        error.Message = row[i].ToString();
                    }
                }

                errors.Add(error);
            }

            return errors;
        }

        private ErrorHeaders FindHeaders(QueryResults result)
        {
            ErrorHeaders headers = new();
            IList<Column> allColumns = result.Tables[0].Columns;

            for (int i = 0; i < allColumns.Count; i++)
            {
                if (allColumns[i].Name == "problemId")
                {
                    headers.ProblemId = i;
                }

                if (allColumns[i].Name == "outerMessage")
                {
                    headers.Message = i;
                }
            }

            return headers;
        }
    }
}

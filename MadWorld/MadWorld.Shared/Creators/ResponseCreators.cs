using System;
using MadWorld.Shared.Web.Models;

namespace MadWorld.Shared.Web.Creators
{
	public static class ResponseCreators
	{
        public static T CreateErrorResponse<T>(string errorMessage) where T : BaseResponse, new()
        {
            return new T()
            {
                Error = true,
                ErrorMessage = errorMessage
            };
        }
    }
}


using System;
using MadWorld.Shared.Models;

namespace MadWorld.Shared.Creators
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


using System;
using MadWorld.Website.JavascriptManager;
using MadWorld.Website.JavascriptManager.Interfaces;
using Microsoft.JSInterop;

namespace MadWorld.Website.Extension
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection AddInternalClasses(this IServiceCollection services)
        {
			return services;
        }
	}
}


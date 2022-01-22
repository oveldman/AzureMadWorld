using System;
using MadWorld.Shared.DesignPattern;
using MadWorld.Website.JavascriptManager;
using MadWorld.Website.JavascriptManager.Interfaces;
using MadWorld.Website.Manager;
using MadWorld.Website.Manager.Interfaces;
using MadWorld.Website.Models.Tools.Running;
using MadWorld.Website.Services.Admin;
using MadWorld.Website.Services.Admin.Interfaces;
using MadWorld.Website.Services.Authorization;
using MadWorld.Website.Services.Info;
using MadWorld.Website.Services.Interfaces;
using MadWorld.Website.Services.Support;
using MadWorld.Website.Services.Tools;
using MadWorld.Website.State;
using MadWorld.Website.State.Interface;
using Microsoft.JSInterop;

namespace MadWorld.Website.Extension
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection AddInternalClasses(this IServiceCollection services)
        {
            //Design pattern
            services.AddScoped<Iterator<RunRound>, RunRoundIterator>();

            //Managers
            services.AddScoped<IRunningManager, RunningManager>();
            services.AddScoped<IAudioManager, AudioManager>();
            services.AddScoped<ISmartlookManager, SmartlookManager>();

            // Services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IIpfsManagerService, IpfsManagerService>();
            services.AddScoped<IIpfsService, IpfsService>();
            services.AddScoped<IResumeService, ResumeService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IUserManagerService, UserManagerService>();

            // State
            services.AddScoped<IAuthenticationHandler, AuthenticationHandler>();
            return services;
        }
	}
}


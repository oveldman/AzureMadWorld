using System;
using System.Threading.Tasks;
using MadWorld.API.SignalR.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace MadWorld.API.SignalR
{
    public class GeneralHubManager : IGeneralHubManager
    {
        private readonly IHubContext<GeneralHub> _hubContext;

        public GeneralHubManager(IHubContext<GeneralHub> hubContext)
        {
            _hubContext = Guard.Against.Null(hubContext);
        }

        public async Task ResetRoles()
        {
            await _hubContext.Clients.All.SendAsync("ResetRoles", true);
        }
    }
}


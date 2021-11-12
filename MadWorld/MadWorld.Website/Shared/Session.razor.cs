using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace MadWorld.Website.Shared
{
    public partial class Session
    {
        protected override void OnInitialized()
        {
            SetupHub();
        }

        private void SetupHub()
        {
            _hubConnection.On<bool>("ResetRoles", (reset) =>
            {
                if (reset)
                {
                    _authenticationHandler.ResetRoles();
                }

                StateHasChanged();
            });
        }
    }
}


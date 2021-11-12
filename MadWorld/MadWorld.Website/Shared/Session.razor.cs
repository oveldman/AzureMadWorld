using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace MadWorld.Website.Shared
{
    public partial class Session
    {
        protected override async Task OnInitializedAsync()
        {
            await SetupHub();
        }

        private async Task SetupHub()
        {
            _hubConnection.On<bool>("ResetRoles", (reset) =>
            {
                if (reset)
                {
                    _authenticationHandler.ResetRoles();
                }

                StateHasChanged();
            });

            await _hubConnection.StartAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _hubConnection.DisposeAsync();
        }
    }
}


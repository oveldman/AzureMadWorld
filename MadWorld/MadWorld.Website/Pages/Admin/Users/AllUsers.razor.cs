using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MadWorld.Shared.Models.Admin;

namespace MadWorld.Website.Pages.Admin.Users
{
    public partial class AllUsers
    {
        private bool PageLoaded = false;
        private string ErrorMessage = string.Empty;

        private List<UserDTO> Users = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadUsers();
        }

        private async Task LoadUsers()
        {
            UsersResponse response = await _service.GetUsers();

            if (!response.Error)
            {
                Users = response.Users;
            }
            else
            {
                ErrorMessage = "There went something wrong with loading users";
            }

            PageLoaded = true;
        }

        private void OpenUser(UserDTO user)
        {
            ErrorMessage = "There is no user page yet";
            StateHasChanged();
        }
    }
}


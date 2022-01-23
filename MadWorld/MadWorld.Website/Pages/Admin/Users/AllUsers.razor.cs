using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MadWorld.Shared.Web.Models.Admin;

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

                PageLoaded = true;
                return;
            }

            ErrorMessage = "There went something wrong with loading users";
        }

        private void OpenUser(UserDTO user)
        {
            Navigation.NavigateTo($"/Admin/EditUser/{user.ID}");
        }
    }
}


using System;
using System.Threading.Tasks;
using MadWorld.Shared.Models;
using MadWorld.Shared.Models.Admin;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Admin.Users
{
    public partial class EditUser
    {
        private bool PageLoaded = false;
        private string ErrorMessage = string.Empty;

        [Parameter]
        public string ID { get; set; }
        private UserDTO User = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadUser();
        }

        private async Task LoadUser()
        {
            UserResponse response = await _service.GetUser(ID);

            if (!response.Error)
            {
                User = new UserDTO
                {
                    ID = response.ID.Value,
                    Email = response.Email,
                    IsAdmin = response.IsAdmin
                };

                PageLoaded = true;
                return;
            }

            ErrorMessage = "There went something wrong while loading the user";
        }

        private async Task SaveUser()
        {
            Reset();

            BaseResponse response = await _service.SaveUser(User);

            if (!response.Error)
            {
                Navigation.NavigateTo($"/Admin/Users");
            }
            else
            {
                ErrorMessage = "There went something wrong with saving the user";
            }
        }

        private void Reset()
        {
            ErrorMessage = String.Empty;
        }
    }
}


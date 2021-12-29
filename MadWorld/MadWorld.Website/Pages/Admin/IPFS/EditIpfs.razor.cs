using System;
using System.Threading.Tasks;
using MadWorld.Shared.Models;
using MadWorld.Shared.Models.Admin.IPFS;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Admin.IPFS
{
	public partial class EditIpfs
	{
        private bool PageLoaded = false;
        private string ErrorMessage = string.Empty;
        private string Title = "Edit IPFS file";
        private string SaveText = "Update file";

        [Parameter]
        public string ID { get; set; }
        private IpfsAdminDTO IpfsFile = new();
        private bool IsNew
        {
            get
            {
                return string.IsNullOrWhiteSpace(ID) || ID == "0";
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await Load();
        }

        private async Task Load()
        {
            if (IsNew)
            {
                Title = "New IPFS file";
                SaveText = "Create file";
            }

            if (!IsNew)
            {
                IpfsAdminDetailResponse response = await _service.GetDetails(ID);

                if (!response.Error)
                {
                    IpfsFile = response.Details;

                    PageLoaded = true;
                    return;
                }

                ErrorMessage = "There went something wrong while loading the file";
            }

            PageLoaded = true;
        }

        private async Task Save()
        {
            BaseResponse response = await _service.Save(IpfsFile);

            if (!response.Error)
            {
                Navigation.NavigateTo($"/Admin/Ipfs/All");
            }
            else
            {
                ErrorMessage = "There went something wrong while saving the file";
            }
        }
    }
}


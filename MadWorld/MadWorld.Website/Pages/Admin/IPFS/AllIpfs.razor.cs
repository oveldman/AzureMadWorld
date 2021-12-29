using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWorld.Shared.Models;
using MadWorld.Shared.Models.Admin.IPFS;

namespace MadWorld.Website.Pages.Admin.IPFS
{
	public partial class AllIpfs
	{
		private bool PageLoaded = false;
		private bool ShowError = false;
		private List<IpfsAdminDTO> Files = new();

		protected override async Task OnInitializedAsync()
		{
			await LoadFiles();
		}

		private async Task LoadFiles()
        {
			IpfsAdminSearchResponse response = await _service.Search();

			if (!response.Error)
            {
				Files = response.Result;
            }

			ShowError = response.Error;
			PageLoaded = true;
		}

		private async Task DeleteFile(Guid? guid)
        {
			BaseResponse response = await _service.Delete(guid.Value.ToString());

			if (!response.Error)
			{
				IpfsAdminDTO file = Files.FirstOrDefault(f => f.ID == guid);
				Files.Remove(file);
			}

			ShowError = response.Error;
		}

		private void EditFile(Guid? id)
        {
			Navigation.NavigateTo($"/Admin/Ipfs/Edit/{id}");
		}

		private void NewFile()
		{
			Navigation.NavigateTo($"/Admin/Ipfs/Edit/0");
		}

		private void IgnoreClick()
        {
			return;
        }
	}
}


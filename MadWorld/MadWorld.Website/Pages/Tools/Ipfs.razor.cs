using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MadWorld.Shared.Web.Models.IPFS;

namespace MadWorld.Website.Pages.Tools
{
	public partial class Ipfs
	{
		private bool PageLoaded = false;
		private bool ShowError = false;
		private List<IpfsDTO> Files = new();

		protected override async Task OnInitializedAsync()
		{
			await LoadFiles();
		}

		private async Task LoadFiles()
        {
			IpfsSearchResponse response = await _service.Search();

			if (!response.Error)
            {
				Files = response.Result;
            }

			PageLoaded = true;
        }

		private async Task DownloadFileFromIpfs(string hash)
        {
		    IpfsDetailResponse response = await _service.GetDetails(hash);

			ShowError = response.Error;

			if (!response.Error)
            {
				await _blazorDownloadFileService.DownloadFile(response.Details.Name, response.Body, response.Details.FileType);
				return;
			}
		}
	}
}


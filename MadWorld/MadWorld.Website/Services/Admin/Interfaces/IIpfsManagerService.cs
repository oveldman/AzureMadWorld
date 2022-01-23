using System;
using System.Threading.Tasks;
using MadWorld.Shared.Web.Models;
using MadWorld.Shared.Web.Models.Admin.IPFS;

namespace MadWorld.Website.Services.Admin.Interfaces
{
	public interface IIpfsManagerService
	{
		public Task<BaseResponse> Delete(string id);
		public Task<IpfsAdminDetailResponse> GetDetails(string id);
		public Task<BaseResponse> Save(IpfsAdminDTO file);
		public Task<IpfsAdminSearchResponse> Search();
	}
}


using System;
using System.Threading.Tasks;
using MadWorld.Shared.Web.Models;
using MadWorld.Shared.Web.Models.Admin.IPFS;
using MadWorld.Shared.Web.Models.IPFS;

namespace MadWorld.Business.Manager.Interfaces
{
	public interface IIpfsManager
	{
		BaseResponse Delete(Guid id);
		Task<IpfsDetailResponse> GetDetails(string hash);
		IpfsAdminDetailResponse GetDetails(Guid id);
		BaseResponse Save(IpfsAdminDTO file);
		IpfsSearchResponse Search();
		IpfsAdminSearchResponse SearchWithID();
	}
}


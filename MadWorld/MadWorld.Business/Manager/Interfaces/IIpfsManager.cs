using System;
using System.Threading.Tasks;
using MadWorld.Shared.Models;
using MadWorld.Shared.Models.Admin.IPFS;
using MadWorld.Shared.Models.IPFS;

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


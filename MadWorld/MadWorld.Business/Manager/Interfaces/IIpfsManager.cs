using System;
using System.Threading.Tasks;
using MadWorld.Shared.Models.IPFS;

namespace MadWorld.Business.Manager.Interfaces
{
	public interface IIpfsManager
	{
		Task<IpfsDetailResponse> GetDetails(string hash);
		IpfsSearchResponse Search();
	}
}


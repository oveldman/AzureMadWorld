using System;
using System.Threading.Tasks;
using MadWorld.Shared.Web.Models.IPFS;

namespace MadWorld.Website.Services.Interfaces
{
	public interface IIpfsService
	{
		Task<IpfsSearchResponse> Search();
		Task<IpfsDetailResponse> GetDetails(string hash);
	}
}


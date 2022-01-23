using System;
using MadWorld.Shared.Web.Models.IPFS;

namespace MadWorld.Shared.Web.Models.Admin.IPFS
{
	public class IpfsAdminDetailResponse : BaseResponse
	{
		public IpfsAdminDTO Details { get; set; } = new();
	}
}


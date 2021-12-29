using System;
using MadWorld.Shared.Models.IPFS;

namespace MadWorld.Shared.Models.Admin.IPFS
{
	public class IpfsAdminDetailResponse : BaseResponse
	{
		public IpfsAdminDTO Details { get; set; } = new();
	}
}


using System;
using System.Collections.Generic;

namespace MadWorld.Shared.Models.Admin.IPFS
{
	public class IpfsAdminSearchResponse : BaseResponse
	{
		public List<IpfsAdminDTO> Result { get; set; } = new();
	}
}


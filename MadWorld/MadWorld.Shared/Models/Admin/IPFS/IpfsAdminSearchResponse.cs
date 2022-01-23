using System;
using System.Collections.Generic;

namespace MadWorld.Shared.Web.Models.Admin.IPFS
{
	public class IpfsAdminSearchResponse : BaseResponse
	{
		public List<IpfsAdminDTO> Result { get; set; } = new();
	}
}


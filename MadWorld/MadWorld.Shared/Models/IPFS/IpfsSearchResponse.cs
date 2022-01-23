using System;
using System.Collections.Generic;

namespace MadWorld.Shared.Web.Models.IPFS
{
	public class IpfsSearchResponse : BaseResponse
	{
		public List<IpfsDTO> Result { get; set; } = new();
	}
}


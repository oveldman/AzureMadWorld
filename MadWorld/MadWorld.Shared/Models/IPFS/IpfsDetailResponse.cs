using System;
namespace MadWorld.Shared.Web.Models.IPFS
{
	public class IpfsDetailResponse : BaseResponse
	{
		public IpfsDTO Details { get; set; } = new();
		public string Body { get; set; } = string.Empty;
	}
}


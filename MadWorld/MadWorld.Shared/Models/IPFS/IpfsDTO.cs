using System;
using System.ComponentModel.DataAnnotations;

namespace MadWorld.Shared.Models.IPFS
{
	public class IpfsDTO
	{
		[Required]
		public string FileType { get; set; } = string.Empty;
		[Required]
		public string Hash { get; set; } = string.Empty;
		[Required]
		public string Name { get; set; } = string.Empty;
		public string Url { get; set; } = string.Empty;
	}
}


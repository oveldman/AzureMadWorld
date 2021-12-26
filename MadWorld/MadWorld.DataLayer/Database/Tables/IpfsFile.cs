using System;
using System.ComponentModel.DataAnnotations;

namespace MadWorld.DataLayer.Database.Tables
{
	public class IpfsFile
	{
		[Key]
		public Guid ID { get; set; }
		public string Hash { get; set; }
		public string Name { get; set; }
		public string ContentType { get; set; }
	}
}


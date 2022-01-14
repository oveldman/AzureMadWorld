using System;
namespace MadWorld.Website.Models.Tools.Running
{
	public class RunRound
	{
		public Guid ID { get; set; }
		public RunType Type { get; set; }
		public TimeSpan Duration { get; set; }
	}
}


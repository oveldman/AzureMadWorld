using System;
using System.Timers;
using MadWorld.Website.Models.Tools.Running;

namespace MadWorld.Website.Manager.Interfaces
{
	public interface IRunningManager
	{
		Guid AddRound(RunType type, TimeSpan duration);
		void SetAudioID(string playerID);
		void SetUpdateScreenFunction(Action updateScreenFunction);
		TimeSpan GetTimeLeft();
		int GetCurrentRound();
		void GiveSound();
		void StartRun();
	}
}


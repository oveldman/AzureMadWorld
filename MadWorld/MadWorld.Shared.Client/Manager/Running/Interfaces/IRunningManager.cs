using System;
using System.Collections.Generic;
using MadWorld.Shared.Client.Models.Tools.Running;

namespace MadWorld.Shared.Client.Manager.Running.Interfaces
{
	public interface IRunningManager
	{
		Guid AddRound(RunType type, TimeSpan duration);
		void AddRounds(List<RunRound> rounds);
		void SetAudioID(string playerID);
		void SetUpdateScreenFunction(Action updateScreenFunction);
		TimeSpan GetTimeLeft();
		int GetCurrentRound();
		void GiveSound();
		void StartRun();
	}
}


using System;
using System.Collections.Generic;
using MadWorld.Shared.Client.Models.Tools.Running;

namespace MadWorld.Shared.Client.Manager.Running.Interfaces
{
    public interface IRunningBuilder
    {
        void SetAudioID(string playerID);
        void GiveSound();
        Guid AddRound(RunType type, TimeSpan duration);
        void AddRounds(List<RunRound> rounds);
        void SetUpdateScreenFunction(Action updateScreenFunction);
        IRunningStopWatch CreateStopWatch();
    }
}
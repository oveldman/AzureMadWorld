using System;

namespace MadWorld.Shared.Client.Manager.Running.Interfaces
{
    public interface IRunningStopWatch
    {
        void StartRun();
        void GiveSound();
        TimeSpan GetTimeLeft();
        int GetCurrentRound();
    }
}
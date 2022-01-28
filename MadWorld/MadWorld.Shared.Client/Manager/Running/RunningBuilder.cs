using System;
using System.Collections.Generic;
using MadWorld.Shared.Client.JavascriptManager.Interface;
using MadWorld.Shared.Client.Manager.Running.Interfaces;
using MadWorld.Shared.Client.Models.Tools.Running;
using MadWorld.Shared.Common.DesignPattern.Iterator;

namespace MadWorld.Shared.Client.Manager.Running
{
    public class RunningBuilder : RunningBase, IRunningBuilder
    {
        public RunningBuilder(IAudioManager audioManager, Iterator<RunRound> runRoundIterator) : base(audioManager, runRoundIterator)
        {
        }
        
        public void SetAudioID(string playerID)
        {
            _audioManager.Init(playerID);
        }

        public Guid AddRound(RunType type, TimeSpan duration)
        {
            Guid roundID = Guid.NewGuid();

            var newRound = new RunRound
            {
                ID = roundID,
                Type = type,
                Duration = duration
            };

            _roundIterator.Add(newRound);

            return roundID;
        }
        
        public void AddRounds(List<RunRound> rounds)
        {
            _roundIterator.Add(rounds);
        }
        
        public void SetUpdateScreenFunction(Action updateScreenFunction)
        {
            UpdateScreen = updateScreenFunction;
        }

        public IRunningStopWatch CreateStopWatch()
        {
            return new RunningStopWatch(_audioManager, _roundIterator, UpdateScreen);
        }
    }
}
using System;
using MadWorld.Shared.Client.JavascriptManager.Interface;
using MadWorld.Shared.Client.Models.Tools.Running;
using MadWorld.Shared.Common.DesignPattern.Iterator;

namespace MadWorld.Shared.Client.Manager.Running
{
    public abstract class RunningBase
    {
        protected Action UpdateScreen = EmptyFunction;
        
        protected Iterator<RunRound> _roundIterator;
        protected IAudioManager _audioManager;

        public RunningBase(IAudioManager audioManager, Iterator<RunRound> runRoundIterator)
        {
            _roundIterator = runRoundIterator;
            _audioManager = audioManager;
        }
        
        public void GiveSound()
        {
            _audioManager.Play();
        }
        
        private static void EmptyFunction()
        {
            return;
        }
    }
}
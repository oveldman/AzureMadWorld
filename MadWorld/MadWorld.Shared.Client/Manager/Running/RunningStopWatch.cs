using System;
using MadWorld.Shared.Client.JavascriptManager.Interface;
using MadWorld.Shared.Client.Manager.Running.Interfaces;
using MadWorld.Shared.Client.Models.Tools.Running;
using MadWorld.Shared.Common.DesignPattern.Iterator;

namespace MadWorld.Shared.Client.Manager.Running
{
    public class RunningStopWatch : RunningBase, IRunningStopWatch 
    {
        private DateTime FinishedTime = DateTime.Now;
        private int Round = 0;
        private RunRound CurrentRound = new RunRound();

        private System.Timers.Timer StopWatchSound = new System.Timers.Timer();
        private System.Timers.Timer StopWatchDisplay = new System.Timers.Timer();

        public RunningStopWatch(IAudioManager audioManager, Iterator<RunRound> runRoundIterator, Action updateScreenMethod)  : base(audioManager, runRoundIterator)
        {
            UpdateScreen = updateScreenMethod;
        }
        
        public void StartRun()
        {
            GetNewRound();
            SetTimer();
        }

        private void SetTimer()
        {
            StopTimers();

            StopWatchSound = new System.Timers.Timer(CurrentRound.Duration.TotalMilliseconds);
            StopWatchDisplay = new System.Timers.Timer(200);
            StopWatchSound.Elapsed += ActivateNewRound;
            StopWatchDisplay.Elapsed += delegate { UpdateScreen(); };
            StopWatchSound.Enabled = true;
            SetFinishedTime();
            StopWatchDisplay.Enabled = true;
        }

        private void ActivateNewRound(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (_roundIterator.HasNext())
            {
                GetNewRound();
                GiveSound();
                SetTimer();

                return;
            }

            StopTimers();
            _roundIterator.ResetPosition();
        }

        private void GetNewRound()
        {
            CurrentRound = _roundIterator.Next();
            RoundUp();
        }

        private void StopTimers()
        {
            StopWatchSound.Enabled = false;
            StopWatchDisplay.Enabled = false;
        }

        private void SetFinishedTime()
        {
            FinishedTime = DateTime.Now.AddMilliseconds(CurrentRound.Duration.TotalMilliseconds);
        }

        private void RoundUp()
        {
            if (CurrentRound.Type == RunType.Run)
            {
                Round++;
            }
        }

        public TimeSpan GetTimeLeft()
        {
            return FinishedTime - DateTime.Now;
        }

        public int GetCurrentRound()
        {
            return Round;
        }
    }
}
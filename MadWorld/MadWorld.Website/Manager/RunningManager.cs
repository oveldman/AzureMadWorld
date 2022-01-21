using System;
using System.Timers;
using MadWorld.Shared.DesignPattern;
using MadWorld.Website.JavascriptManager.Interfaces;
using MadWorld.Website.Manager.Interfaces;
using MadWorld.Website.Models.Tools.Running;

namespace MadWorld.Website.Manager
{
	public class RunningManager : IRunningManager
	{
        private DateTime FinishedTime = DateTime.Now;
        private int Round = 0;
        private Iterator<RunRound> _roundIterator;
        private RunRound CurrentRound = new();

        private System.Timers.Timer StopWatchSound = new();
        private System.Timers.Timer StopWatchDisplay = new();

        private Action UpdateScreen = EmptyFunction;

        private IAudioManager _audioManager;

		public RunningManager(IAudioManager audioManager, Iterator<RunRound> runRoundIterator)
		{
			_audioManager = audioManager;
            _roundIterator = runRoundIterator;
		}

        public void SetAudioID(string playerID)
        {
            _audioManager.Init(playerID);
        }

        public void StartRun()
        {
            GetNewRound();
            SetTimer();
        }

        private void SetTimer()
        {
            StopTimers();

            StopWatchSound = new(CurrentRound.Duration.TotalMilliseconds);
            StopWatchDisplay = new(200);
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

        public void GiveSound()
        {
            _audioManager.Play();
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

        public TimeSpan GetTimeLeft()
        {
            return FinishedTime - DateTime.Now;
        }

        public int GetCurrentRound()
        {
            return Round;
        }

        private static void EmptyFunction()
        {
            return;
        }

        public void SetUpdateScreenFunction(Action updateScreenFunction)
        {
            UpdateScreen = updateScreenFunction;
        }

        public void AddRounds(List<RunRound> rounds)
        {
            _roundIterator.Add(rounds);
        }
    }
}


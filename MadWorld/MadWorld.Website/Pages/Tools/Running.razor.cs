using System;
namespace MadWorld.Website.Pages.Tools
{
	public partial class Running
	{
        private readonly string PlayerID = "running-audio";
        private System.Timers.Timer StopWatchSound = new();
        private System.Timers.Timer StopWatchDisplay = new();
        private int Time = 120000;
        private double Round = 0.5;
        private DateTime FinishedTime = DateTime.Now;
        private TimeSpan TimeLeft = new();

        protected override void OnAfterRender(bool firstRender)
        {
            _audioManager.Init(PlayerID);
        }

        private void Play(Object source, System.Timers.ElapsedEventArgs e)
        {
            Play();
            SetTimer();
        }

        private void Play()
        {
            _audioManager.Play();
        }

        private void Start()
        {
            SetTimer();
        }

        private void SetTimer()
        {
            StopWatchSound.Enabled = false;
            StopWatchDisplay.Enabled = false;

            StopWatchSound = new(Time);
            StopWatchDisplay = new(200);
            StopWatchSound.Elapsed += Play;
            StopWatchDisplay.Elapsed += UpdateDisplayTime;
            StopWatchSound.Enabled = true;
            SetFinishedTime();
            StopWatchDisplay.Enabled = true;
        }

        private void UpdateDisplayTime(Object source, System.Timers.ElapsedEventArgs e)
        {
            TimeLeft = FinishedTime - DateTime.Now;
            StateHasChanged();
        }

        private void SetFinishedTime()
        {
            Round += 0.5;
            FinishedTime = DateTime.Now.AddMilliseconds(Time);
            StateHasChanged();
        }
    }
}


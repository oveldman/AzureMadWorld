using System;
using MadWorld.Website.Models.Tools.Running;

namespace MadWorld.Website.Pages.Tools
{
	public partial class Running
	{
        private readonly string PlayerID = "running-audio";
        private TimeSpan TimeLeft = new();
        private int Round = 0;

        protected override void OnAfterRender(bool firstRender)
        {
            _manager.SetAudioID(PlayerID);
            _manager.SetUpdateScreenFunction(UpdateDisplayTime);
        }

        private void AddItems()
        {
            _manager.AddRound(RunType.Run, new TimeSpan(0, 2, 0));
            _manager.AddRound(RunType.Walk, new TimeSpan(0, 2, 0));
            _manager.AddRound(RunType.Run, new TimeSpan(0, 2, 0));
            _manager.AddRound(RunType.Walk, new TimeSpan(0, 2, 0));
            _manager.AddRound(RunType.Run, new TimeSpan(0, 2, 0));
            _manager.AddRound(RunType.Walk, new TimeSpan(0, 2, 0));
            _manager.AddRound(RunType.Run, new TimeSpan(0, 2, 0));
            _manager.AddRound(RunType.Walk, new TimeSpan(0, 2, 0));
            _manager.AddRound(RunType.Run, new TimeSpan(0, 2, 0));
            _manager.AddRound(RunType.Walk, new TimeSpan(0, 2, 0));
        }

        private void Test()
        {
            _manager.GiveSound();
        }

        private void Start()
        {
            _manager.StartRun();
        }

        private void UpdateDisplayTime()
        {
            TimeLeft = _manager.GetTimeLeft();
            Round = _manager.GetCurrentRound();
            StateHasChanged();
        }
    }
}


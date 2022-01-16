using System;
using MadWorld.Website.Models.Tools.Running;

namespace MadWorld.Website.Pages.Tools
{
	public partial class Running
	{
        private readonly string PlayerID = "running-audio";
        private TimeSpan TimeLeft = new();
        private int Round = 0;

        private bool RunStarted = false;
        private bool ShowNewRunInputs = false;
        private RunType RunType = RunType.None;
        private int DurationMinutes = 0;
        private List<RunRound> AllRounds = new();

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

        private void AddWalk()
        {
            RunType = RunType.Walk;
            DurationMinutes = 0;
            ShowNewRunInputs = true;
        }

        private void AddRun()
        {
            RunType = RunType.Run;
            DurationMinutes = 0;
            ShowNewRunInputs = true;
        }

        private void ConfirmRound()
        {
            TimeSpan duration = new TimeSpan(0, DurationMinutes, 0);
            Guid runID = _manager.AddRound(RunType, duration);
            ShowNewRunInputs = false;

            AllRounds.Add(new RunRound {
                ID = runID,
                Duration = duration,
                Type = RunType
            });
        }

        private void Test()
        {
            _manager.GiveSound();
        }

        private void Start()
        {
            _manager.StartRun();
            RunStarted = true;
        }

        private void UpdateDisplayTime()
        {
            TimeLeft = _manager.GetTimeLeft();
            Round = _manager.GetCurrentRound();
            StateHasChanged();
        }

        private string DisplayTimespan(TimeSpan time)
        {
            return $"{time.Hours:00}:{time.Minutes:00}:{time.Seconds:00}";
        }

        private string GetBlockColour(RunType runType) => runType switch
        {
            RunType.Run => "bg-c-green",
            RunType.Walk => "bg-c-blue",
            RunType.None => "bg-c-yellow",
            _ => "bg-c-yellow"
        };
    }
}


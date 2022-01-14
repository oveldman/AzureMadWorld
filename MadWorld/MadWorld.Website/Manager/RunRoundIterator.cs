using System;
using MadWorld.Shared.DesignPattern;
using MadWorld.Website.Models.Tools.Running;

namespace MadWorld.Website.Manager
{
    public class RunRoundIterator : Iterator<RunRound>
    {
        private bool HasStarted;
        private List<RunRound> Runs;
        private int Postition = 0;

        public RunRoundIterator()
        {
            Runs = new();
        }

        public void Add(RunRound item)
        {
            if (HasStarted)
            {
                throw new IteratorStartedException(nameof(RunRoundIterator));
            }

            Runs.Add(item);
        }

        public bool HasNext()
        {
            return Runs.Count > Postition;
        }

        public RunRound Next()
        {
            HasStarted = true;
            RunRound round = Runs[Postition];
            Postition++;
            return round;
        }

        public void ResetPosition()
        {
            Postition = 0;
            HasStarted = false;
        }
    }
}


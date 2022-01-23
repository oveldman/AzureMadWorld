using System;
using MadWorld.Shared.Web.DesignPattern;
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
            CheckRunStartedAndThrowException();

            Runs.Add(item);
        }

        public void Add(List<RunRound> items)
        {
            if (items == null) return;

            CheckRunStartedAndThrowException();

            Runs.AddRange(items);
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

        private void CheckRunStartedAndThrowException()
        {
            if (HasStarted)
            {
                throw new IteratorStartedException(nameof(RunRoundIterator));
            }
        }
    }
}


using System;
using System.Collections.Generic;
using MadWorld.Shared.Client.Models.Tools.Running;
using MadWorld.Shared.Common.DesignPattern.Iterator;

namespace MadWorld.Shared.Client.Manager.Running
{
    public class RunRoundIterator : Iterator<RunRound>
    {
        private bool HasStarted;
        private List<RunRound> Runs;
        private int Postition = 0;

        public RunRoundIterator()
        {
            Runs = new List<RunRound>();
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


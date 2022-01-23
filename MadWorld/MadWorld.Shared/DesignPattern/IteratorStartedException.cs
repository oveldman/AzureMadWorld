using System;
namespace MadWorld.Shared.Web.DesignPattern
{
	public class IteratorStartedException : Exception
	{
        public IteratorStartedException() { }

        public IteratorStartedException(string message)
            : base(String.Format("The iterator has already started with message: {0}", message))
        {

        }
    }
}


using System;
namespace MadWorld.Optional
{
    public class None<T> : Option<T>
    {
        public override bool HasValue => false;

        public override T GetValue()
        {
            throw new NullReferenceException();
        }
    }
}


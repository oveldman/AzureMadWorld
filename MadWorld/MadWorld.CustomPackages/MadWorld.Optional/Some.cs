using System;
namespace MadWorld.Optional
{
    public class Some<T> : Option<T>
    {
        public T Value { get; set; }

        public override bool HasValue => true;

        public Some(T value)
        {
            Value = value;
        }

        public override T GetValue()
        {
            return Value;
        }
    }
}


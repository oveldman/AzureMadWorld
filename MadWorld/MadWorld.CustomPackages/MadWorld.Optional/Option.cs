using MadWorld.Optional.Interfaces;

namespace MadWorld.Optional;

public abstract class Option<T> : IOption<T>
{
    public abstract bool HasValue { get; }

    public static None<T> CreateNone()
    {
        return new None<T>();
    }

    public static Some<T> CreateSome(T value)
    {
        return new Some<T>(value);
    }

    public Y Match<Y>(Func<T, Y> some, Func<Y> none)
    {
        switch (this)
        {
            case Some<T>:
                return some(this.GetValue());
            case None<T>:
            default:
                return none();
        }
    }

    public abstract T GetValue();
}


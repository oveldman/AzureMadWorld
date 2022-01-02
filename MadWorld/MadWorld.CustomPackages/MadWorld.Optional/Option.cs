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

    public abstract T GetValue();
}


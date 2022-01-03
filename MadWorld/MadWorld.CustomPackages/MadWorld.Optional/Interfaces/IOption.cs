using System;
namespace MadWorld.Optional.Interfaces
{
	public interface IOption<T>
	{
		bool HasValue { get; }

		T GetValue();
		Y Match<Y>(Func<T, Y> some, Func<Y> none);
	}
}


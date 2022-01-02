using System;
namespace MadWorld.Optional.Interfaces
{
	public interface IOption<T>
	{
		bool HasValue { get; }

		T GetValue();
	}
}


using System;
namespace MadWorld.Shared.DesignPattern
{
	public interface Iterator<T>
	{
		void Add(T item);
		T Next();
		bool HasNext();
		void ResetPosition();
	}
}


using System;
namespace MadWorld.Shared.DesignPattern
{
	public interface Iterator<T>
	{
		void Add(T item);
		void Add(List<T> items);
		T Next();
		bool HasNext();
		void ResetPosition();
	}
}


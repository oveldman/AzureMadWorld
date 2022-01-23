using System;
using System.Collections.Generic;

namespace MadWorld.Shared.Common.DesignPattern.Iterator
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


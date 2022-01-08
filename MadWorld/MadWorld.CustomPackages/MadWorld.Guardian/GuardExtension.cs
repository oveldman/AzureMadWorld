using System;
namespace MadWorld.Guardian
{
	public static class GuardExtension
	{
		public static T CheckNull<T>(this Guard guard, T value)
        {
			if (value is null)
            {
				throw new ArgumentNullException($"The object '{typeof(T).Name}' must have a value");
            }

			return value;
        }
	}
}


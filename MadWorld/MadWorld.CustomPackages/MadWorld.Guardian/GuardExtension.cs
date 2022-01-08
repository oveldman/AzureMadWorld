using System;
namespace MadWorld.Guardian
{
	public static class GuardExtension
	{
		public static T Null<T>(this IGuardClause guard, T value)
        {
			if (value is null)
            {
				throw new ArgumentNullException($"The object '{typeof(T).Name}' must have a value");
            }

			return value;
        }
	}
}


using System;
namespace MadWorld.Guardian
{
	public static class GuardExtension
	{
		public static T Null<T>(this IGuardClause _, T value, string propertyname)
        {
			if (value is null)
            {
				throw new ArgumentNullException($"The object '{propertyname}' must have a value");
            }

			return value;
        }
	}
}


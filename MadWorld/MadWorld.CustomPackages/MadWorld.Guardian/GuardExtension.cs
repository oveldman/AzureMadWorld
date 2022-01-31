using System;
using System.Runtime.CompilerServices;

namespace MadWorld.Guardian
{
	public static class GuardExtension
	{
		public static T Null<T>(this IGuardClause _, T value, [CallerArgumentExpression("value")]string message = "")
        {
			if (value is null)
            {
				throw new ArgumentNullException(null, message);
            }

			return value;
        }
	}
}


using System;
using MadWorld.Guardian;

namespace MadWorld.Tests.CustomPackages.Guardian
{
	public class GuardTests
	{
		[Theory]
		[AutoDomainData]
		public void AgainstNull_String_String(
			string randomTestData
			)
        {
			// No Test data

			// No Setup

			// Act
			var result = Guard.Against.Null(randomTestData, nameof(randomTestData));

			// Assert
			Assert.Equal(randomTestData, result);

			// No Teardown
		}

		[Fact]
		public void AgainstNull_Null_NullException()
		{
			// Test data
			string? randomTestData = null;

			// No Setup

			// Act
			void TestAgainstNull()
			{
				var result = Guard.Against.Null(randomTestData, nameof(randomTestData));
			}

			// Assert
			Assert.Throws<ArgumentNullException>("The object 'randomTestData' must have a value", TestAgainstNull);

			// No Teardown
		}
	}
}


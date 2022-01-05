using System;
namespace MadWorld.Tests.CustomPackages.Optional
{
	public class SomeTests
	{
        [Theory]
        [AutoDomainData]
        public void HasValue_NoArguments_True(
            Some<int> some
            )
        {
            // No Test data

            // No Setup

            // Act
            bool hasValue = some.HasValue;

            // Assert
            Assert.True(hasValue);

            // No Teardown
        }

        [Fact]
        public void GetValue_NoArguments_Int()
        {
            // Test data
            Some<int> some = new Some<int>(10);

            // No Setup

            // Act
            int value = some.GetValue();

            // Assert
            int expectedValue = 10;
            Assert.Equal(expectedValue, value);
            
            // No Teardown
        }
    }
}


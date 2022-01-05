using System;
namespace MadWorld.Tests.CustomPackages.Optional
{
	public class NoneTests
	{
        [Theory]
        [AutoDomainData]
        public void HasValue_NoArguments_False(
            None<int> none
            )
        {
            // No Test data

            // No Setup

            // Act
            bool hasValue = none.HasValue;

            // Assert
            Assert.False(hasValue);

            // No Teardown
        }

        [Theory]
        [AutoDomainData]
        public void GetValue_NoArguments_NullException(
            None<int> none
            )
        {
            // No Test data

            // No Setup

            // Act
            void TestGetValueOnException()
            {
                none.GetValue();
            }

            // Assert
            Assert.Throws<NullReferenceException>(TestGetValueOnException);

            // No Teardown
        }
    }
}


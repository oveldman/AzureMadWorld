using System;
namespace MadWorld.Tests.CustomPackages.Optional
{
	public class OptionTests
	{
        [Fact]
        public void CreateNone_NoArguments_None()
        {
            // No Test data

            // No Setup

            // Act
            IOption<int> none = Option<int>.CreateNone();

            // Assert
            Assert.IsType<None<int>>(none);

            // No Teardown
        }

        [Theory]
        [AutoDomainData]
        public void CreateSome_RandomInteger_Some(
            int testData)
        {
            // No Test data

            // No Setup

            // Act
            IOption<int> some = Option<int>.CreateSome(testData);

            // Assert
            Assert.IsType<Some<int>>(some);

            // No Teardown
        }

        [Theory]
        [AutoDomainData]
        public void Math_TwoRandomFunctions_Zero(
            None<int> none)
        {
            // No Test data

            // No Setup

            // Act
            int testValue = none.Match<int>(TestSome, TestNone);

            // Assert
            int expectedValue = 0;
            Assert.Equal(expectedValue, testValue);

            // No Teardown
        }

        [Theory]
        [AutoDomainData]
        public void Math_TwoRandomFunctions_One(
            Some<int> some)
        {
            // No Test data

            // No Setup

            // Act
            int testValue = some.Match<int>(TestSome, TestNone);

            // Assert
            int expectedValue = 1;
            Assert.Equal(expectedValue, testValue);

            // No Teardown
        }

        private int TestSome(int testData)
        {
            return 1;
        }

        private int TestNone()
        {
            return 0;
        }
    }
}


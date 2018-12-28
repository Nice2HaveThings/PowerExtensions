using FluentAssertions;
using NUnit.Framework;
using PowerExtensions.Querying;
using System.Linq;

namespace PowerExtensionTests.Querying
{
    [TestFixture]
    public class StringExtensionsTests
    {
        private static TestCaseData[] _atIndexSuccess =
        {
            new TestCaseData("Haus", "au", 1),
            new TestCaseData("Haus", "Ha", 0),
            new TestCaseData("Au", "Au", 0),
        };

        private static TestCaseData[] _atIndexFail =
        {
            new TestCaseData("FuBar", "abc", 1),
            new TestCaseData("Bus", "us", 0),
            new TestCaseData("Bus", "us", 2),
            new TestCaseData("Bus", "Us", 1),
        };

        private static TestCaseData[] _fromIndexSuccess = _atIndexSuccess.Concat(new[]
        {
            new TestCaseData("Auch", "ch", 0),
        }).ToArray();

        private static TestCaseData[] _fromIndexFail =
        {
            new TestCaseData("FuBar", "abc", 1),
            new TestCaseData("Bus", "us", 2),
            new TestCaseData("Bus", "Us", 1),
        };

        private static TestCaseData[] _untilIndexSuccess =
        {
            new TestCaseData("Genug", "enu", 3),
            new TestCaseData("Genug", "enu", 4),
            new TestCaseData("Genug", "Gen", 2),
            new TestCaseData("Jau", "Jau", 2),
        };

        private static TestCaseData[] _untilIndexFail =
        {
            new TestCaseData("FuBar", "abc", 4),
            new TestCaseData("Genug", "enu", 2),
            new TestCaseData("Genug", "eNu", 3),
        };

        [Test]
        [TestCaseSource(nameof(_atIndexSuccess))]
        public void ContainsAtIndex_Valid_ReturnTrue(string str, string substring, int index)
        {
            bool result = str.ContainsAtIndex(substring, index);

            result.Should().BeTrue();
        }

        [Test]
        [TestCaseSource(nameof(_atIndexFail))]
        public void ContainsAtIndex_Invalid_ShouldReturnFalse(string str, string substring, int index)
        {
            bool result = str.ContainsAtIndex(substring, index);

            result.Should().BeFalse();
        }

        [Test]
        [TestCaseSource(nameof(_fromIndexSuccess))]
        public void ContainsFromIndex_Valid_ReturnTrue(string str, string substring, int index)
        {
            bool result = str.ContainsFromIndex(substring, index);

            result.Should().BeTrue();
        }

        [Test]
        [TestCaseSource(nameof(_fromIndexFail))]
        public void ContainsFromIndex_Invalid_ShouldReturnFalse(string str, string substring, int index)
        {
            bool result = str.ContainsFromIndex(substring, index);

            result.Should().BeFalse();
        }

        [Test]
        [TestCaseSource(nameof(_untilIndexSuccess))]
        public void ContainsUntilIndex_Valid_ReturnTrue(string str, string substring, int index)
        {
            bool result = str.ContainsUntilIndex(substring, index);

            result.Should().BeTrue();
        }

        [Test]
        [TestCaseSource(nameof(_untilIndexFail))]
        public void ContainsUntilIndex_Invalid_ShouldReturnFalse(string str, string substring, int index)
        {
            bool result = str.ContainsUntilIndex(substring, index);

            result.Should().BeFalse();
        }
    }
}

using FluentAssertions;
using Moq;
using NUnit.Framework;
using PowerExtensions.Querying;
using System;
using System.Data;

namespace PowerExtensionTests.Querying
{
    [TestFixture]
    public class DataReaderExtensionsTests
    {
        private static TestCaseData[] _readerNullValues =
        {
            new TestCaseData(null),
            new TestCaseData(DBNull.Value),
        };

        [Test]
        public void GetValue_ValidOrdinalValidType_ShouldReturn()
        {
            Mock<IDataReader> mock = new Mock<IDataReader>();
            int ordinal = 1;
            string value = "test";
            mock.Setup(m => m.GetValue(ordinal)).Returns(value);

            string result = mock.Object.GetValue<string>(ordinal);

            result.Should().Be(value);
        }

        [Test]
        public void GetValue_ValidOrdinalInvalidType_ShouldThrow()
        {
            Mock<IDataReader> mock = new Mock<IDataReader>();
            int ordinal = 1;
            string value = "test";
            mock.Setup(m => m.GetValue(ordinal)).Returns(value);

            Action fail = () => mock.Object.GetValue<int>(ordinal);

            fail.Should().Throw<InvalidCastException>();
        }

        [Test]
        public void GetValue_ValidName_ShouldReturn()
        {
            Mock<IDataReader> mock = new Mock<IDataReader>();
            string name = "myProp";
            int ordinal = 1;
            string value = "test";
            mock.Setup(m => m.GetOrdinal(name)).Returns(ordinal);
            mock.Setup(m => m.GetValue(ordinal)).Returns(value);

            string result = mock.Object.GetValue<string>(name);

            result.Should().Be(value);
        }

        [Test]
        public void GetValue_ValidNameInvalidType_ShouldThrow()
        {
            Mock<IDataReader> mock = new Mock<IDataReader>();
            string name = "myProp";
            int ordinal = 1;
            string value = "test";
            mock.Setup(m => m.GetOrdinal(name)).Returns(ordinal);
            mock.Setup(m => m.GetValue(ordinal)).Returns(value);

            Action fail = () => mock.Object.GetValue<int>(name);

            fail.Should().Throw<InvalidCastException>();
        }

        [Test]
        public void GetValueOrDefault_ValidOrdinalValidType_ShouldReturn()
        {
            Mock<IDataReader> mock = new Mock<IDataReader>();
            int ordinal = 1;
            string value = "test";
            mock.Setup(m => m.GetValue(ordinal)).Returns(value);

            string result = mock.Object.GetValueOrDefault<string>(ordinal);

            result.Should().Be(value);
        }

        [Test]
        public void GetValueOrDefault_ValidOrdinalInvalidType_ShouldThrow()
        {
            Mock<IDataReader> mock = new Mock<IDataReader>();
            int ordinal = 1;
            string value = "test";
            mock.Setup(m => m.GetValue(ordinal)).Returns(value);

            Action fail = () => mock.Object.GetValueOrDefault<int>(ordinal);

            fail.Should().Throw<InvalidCastException>();
        }

        [Test]
        public void GetValueOrDefault_ValidName_ShouldReturn()
        {
            Mock<IDataReader> mock = new Mock<IDataReader>();
            string name = "myProp";
            int ordinal = 1;
            string value = "test";
            mock.Setup(m => m.GetOrdinal(name)).Returns(ordinal);
            mock.Setup(m => m.GetValue(ordinal)).Returns(value);

            string result = mock.Object.GetValueOrDefault<string>(name);

            result.Should().Be(value);
        }

        [Test]
        public void GetValueOrDefault_ValidNameInvalidType_ShouldThrow()
        {
            Mock<IDataReader> mock = new Mock<IDataReader>();
            string name = "myProp";
            int ordinal = 1;
            string value = "test";
            mock.Setup(m => m.GetOrdinal(name)).Returns(ordinal);
            mock.Setup(m => m.GetValue(ordinal)).Returns(value);

            Action fail = () => mock.Object.GetValueOrDefault<int>(name);

            fail.Should().Throw<InvalidCastException>();
        }

        [Test]
        [TestCaseSource(nameof(_readerNullValues))]
        public void GetValueOrDefault_FromOrdinalAndFieldNull_ShouldReturnDefault(object value)
        {
            Mock<IDataReader> mock = new Mock<IDataReader>();
            int ordinal = 1;
            mock.Setup(m => m.GetValue(ordinal)).Returns(value);

            int result = mock.Object.GetValueOrDefault<int>(ordinal);

            result.Should().Be(0);
        }

        [Test]
        [TestCaseSource(nameof(_readerNullValues))]
        public void GetValueOrDefault_FromNameAndFieldNull_ShouldReturnDefault(object value)
        {
            Mock<IDataReader> mock = new Mock<IDataReader>();
            string name = "myProp";
            int ordinal = 1;
            mock.Setup(m => m.GetOrdinal(name)).Returns(ordinal);
            mock.Setup(m => m.GetValue(ordinal)).Returns(value);

            int result = mock.Object.GetValueOrDefault<int>(name);

            result.Should().Be(0);
        }
    }
}

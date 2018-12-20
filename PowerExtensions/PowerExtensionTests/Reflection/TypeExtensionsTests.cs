using FluentAssertions;
using NUnit.Framework;
using PowerExtensions.Reflection;
using System;
using System.Collections.Generic;

namespace PowerExtensionTests.Reflection
{
    [TestFixture]
    public class TypeExtensionsTests
    {
        private static TestCaseData[] _simpleTypes = 
        {
            new TestCaseData(typeof(int)),
            new TestCaseData(typeof(short)),
            new TestCaseData(typeof(long)),
            new TestCaseData(typeof(bool)),
            new TestCaseData(typeof(string)),
            new TestCaseData(typeof(decimal)),
            new TestCaseData(typeof(int?)),
            new TestCaseData(typeof(short?)),
            new TestCaseData(typeof(long?)),
            new TestCaseData(typeof(bool?)),
            new TestCaseData(typeof(decimal?)),
            new TestCaseData(typeof(Day)),
        };

        private static TestCaseData[] _complexTypes =
        {
            new TestCaseData(typeof(TypeExtensionsTests)),
            new TestCaseData(typeof(DateTime)),
            new TestCaseData(typeof(List<string>)),
        };

        private static TestCaseData[] _nullableTypes =
        {
            new TestCaseData(typeof(string)),
            new TestCaseData(typeof(TypeExtensionsTests)),
            new TestCaseData(typeof(int?)),
            new TestCaseData(typeof(List<string>)),
            new TestCaseData(typeof(IEnumerable<string>)),
        };

        private static TestCaseData[] _notNullableTypes =
        {
            new TestCaseData(typeof(int)),
            new TestCaseData(typeof(short)),
            new TestCaseData(typeof(long)),
            new TestCaseData(typeof(decimal)),
            new TestCaseData(typeof(Day)),
        };

        [Test]
        [TestCaseSource(nameof(_simpleTypes))]
        public void IsSimple_SimpleType_ShouldBeTrue(Type type)
        {
            bool result = type.IsSimple();

            result.Should().BeTrue();
        }

        [Test]
        [TestCaseSource(nameof(_complexTypes))]
        public void IsSimple_ComplexType_ShouldBeFalse(Type type)
        {
            bool result = type.IsSimple();

            result.Should().BeFalse();
        }

        [Test]
        [TestCaseSource(nameof(_simpleTypes))]
        public void IsComplex_SimpleType_ShouldBeFalse(Type type)
        {
            bool result = type.IsComplex();

            result.Should().BeFalse();
        }

        [Test]
        [TestCaseSource(nameof(_complexTypes))]
        public void IsComplex_ComplexType_ShouldBeTrue(Type type)
        {
            bool result = type.IsComplex();

            result.Should().BeTrue();
        }

        [Test]
        [TestCaseSource(nameof(_nullableTypes))]
        public void IsNullable_NullableType_ShouldBeTrue(Type type)
        {
            bool result = type.IsNullable();

            result.Should().BeTrue();
        }

        [Test]
        [TestCaseSource(nameof(_notNullableTypes))]
        public void IsNullable_NotNullableType_ShouldBeFalse(Type type)
        {
            bool result = type.IsNullable();

            result.Should().BeFalse();
        }

        private enum Day
        {
            Monday,
            Thuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
    }
}

using FluentAssertions;
using NUnit.Framework;
using PowerExtensions.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

        [Test]
        public void GetPropertiesAll_WithClass_ShouldReturnAllPropertes()
        {
            IEnumerable<PropertyInfo> infos = typeof(ReflectionTestClass).GetPropertiesAll();

            infos.Select(i => i.Name).Should().BeEquivalentTo
                (
                    new[]
                    {
                        "PublicStaticProperty",
                        "PrivateStaticProperty",
                        "PublicProperty",
                        "PrivateProperty"
                    }
                );
        }

        [Test]
        public void GetPropertiesAll_WithEnum_ShouldReturnNoProperties()
        {
            IEnumerable<PropertyInfo> infos = typeof(Day).GetPropertiesAll();

            infos.Should().BeEmpty();
        }

        [Test]
        public void GetFieldsAll_WithClass_ShouldReturnAllFields()
        {
            IEnumerable<FieldInfo> infos = typeof(ReflectionTestClass).GetFieldsAll();

            infos.Select(i => i.Name).Should().BeEquivalentTo
                (
                    new[]
                    {
                        "PublicField",
                        "PrivateField"
                    }
                );
        }

        private class ReflectionTestClass
        {
            public static string PublicStaticProperty { get; set; }

            private static string PrivateStaticProperty { get; set; }

            public string PublicProperty { get; set; }

            private string PrivateProperty { get; set; }

            public string PublicField;

            private string PrivateField;
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

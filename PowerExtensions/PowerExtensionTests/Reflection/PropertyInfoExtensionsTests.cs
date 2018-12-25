using FluentAssertions;
using NUnit.Framework;
using PowerExtensions.Reflection;

namespace PowerExtensionTests.Reflection
{
    [TestFixture]
    public class PropertyInfoExtensionsTests
    {
        [Test]
        public void IsPublic_PublicStaticProperty_ShouldBeTrue()
        {
            bool isPublic = typeof(ReflectionTestClass).GetProperty("PublicStaticProperty").IsPublic();

            isPublic.Should().BeTrue();
        }

        [Test]
        public void IsPublic_PublicProperty_ShouldBeTrue()
        {
            bool isPublic = typeof(ReflectionTestClass).GetProperty("PublicProperty").IsPublic();

            isPublic.Should().BeTrue();
        }

        [Test]
        public void IsPublic_InternalProperty_ShouldBeFalse()
        {
            bool isPublic = typeof(ReflectionTestClass).GetProperty("InternalProperty", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).IsPublic();

            isPublic.Should().BeFalse();
        }

        [Test]
        public void IsPublic_PrivateProperty_ShouldBeFalse()
        {
            bool isPublic = typeof(ReflectionTestClass).GetProperty("PrivateProperty", System.Reflection.BindingFlags.Instance|System.Reflection.BindingFlags.NonPublic).IsPublic();

            isPublic.Should().BeFalse();
        }

        [Test]
        public void IsPublic_PrivateStaticProperty_ShouldBeFalse()
        {
            bool isPublic = typeof(ReflectionTestClass).GetProperty("PrivateStaticProperty", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).IsPublic();

            isPublic.Should().BeFalse();
        }

        [Test]
        public void IsNonPublic_PublicStaticProperty_ShouldBeFalse()
        {
            bool isNonPublic = typeof(ReflectionTestClass).GetProperty("PublicStaticProperty").IsNonPublic();

            isNonPublic.Should().BeFalse();
        }

        [Test]
        public void IsNonPublic_PublicProperty_ShouldBeFalse()
        {
            bool isNonPublic = typeof(ReflectionTestClass).GetProperty("PublicProperty").IsNonPublic();

            isNonPublic.Should().BeFalse();
        }

        [Test]
        public void IsNonPublic_InternalProperty_ShouldBeTrue()
        {
            bool isNonPublic = typeof(ReflectionTestClass).GetProperty("InternalProperty", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).IsNonPublic();

            isNonPublic.Should().BeTrue();
        }

        [Test]
        public void IsNonPublic_PrivateStaticProperty_ShouldBeTrue()
        {
            bool isNonPublic = typeof(ReflectionTestClass).GetProperty("PrivateStaticProperty", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).IsNonPublic();

            isNonPublic.Should().BeTrue();
        }

        [Test]
        public void IsNonPublic_PrivateProperty_ShouldBeTrue()
        {
            bool isNonPublic = typeof(ReflectionTestClass).GetProperty("PrivateProperty", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).IsNonPublic();

            isNonPublic.Should().BeTrue();
        }

        [Test]
        public void IsInstance_PublicStaticProperty_ShouldBeFalse()
        {
            bool isInstance = typeof(ReflectionTestClass).GetProperty("PublicStaticProperty").IsInstance();

            isInstance.Should().BeFalse();
        }

        [Test]
        public void IsInstance_PublicProperty_ShouldBeTrue()
        {
            bool isInstance = typeof(ReflectionTestClass).GetProperty("PublicProperty").IsInstance();

            isInstance.Should().BeTrue();
        }

        [Test]
        public void IsInstance_InternalProperty_ShouldBeTrue()
        {
            bool isInstance = typeof(ReflectionTestClass).GetProperty("InternalProperty", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).IsInstance();

            isInstance.Should().BeTrue();
        }

        [Test]
        public void IsInstance_PrivateStaticProperty_ShouldBeFalse()
        {
            bool isInstance = typeof(ReflectionTestClass).GetProperty("PrivateStaticProperty", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).IsInstance();

            isInstance.Should().BeFalse();
        }

        [Test]
        public void IsInstance_PrivateProperty_ShouldBeTrue()
        {
            bool isInstance = typeof(ReflectionTestClass).GetProperty("PrivateProperty", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).IsInstance();

            isInstance.Should().BeTrue();
        }

        [Test]
        public void IsStatic_PublicStaticProperty_ShouldBeTrue()
        {
            bool isStatic = typeof(ReflectionTestClass).GetProperty("PublicStaticProperty").IsStatic();

            isStatic.Should().BeTrue();
        }

        [Test]
        public void IsStatic_PublicProperty_ShouldBeFalse()
        {
            bool isStatic = typeof(ReflectionTestClass).GetProperty("PublicProperty").IsStatic();

            isStatic.Should().BeFalse();
        }

        [Test]
        public void IsStatic_InternalProperty_ShouldBeFalse()
        {
            bool isStatic = typeof(ReflectionTestClass).GetProperty("InternalProperty", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).IsStatic();

            isStatic.Should().BeFalse();
        }

        [Test]
        public void IsStatic_PrivateStaticProperty_ShouldBeTrue()
        {
            bool isStatic = typeof(ReflectionTestClass).GetProperty("PrivateStaticProperty", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).IsStatic();

            isStatic.Should().BeTrue();
        }

        [Test]
        public void IsStatic_PrivateProperty_ShouldBeFalse()
        {
            bool isStatic = typeof(ReflectionTestClass).GetProperty("PrivateProperty", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).IsStatic();

            isStatic.Should().BeFalse();
        }

        private class ReflectionTestClass
        {
            public static string PublicStaticProperty { get; set; }

            internal static string InternalStaticProperty { get; set; }

            private static string PrivateStaticProperty { get; set; }

            public string PublicProperty { get; set; }

            internal string InternalProperty { get; set; }

            private string PrivateProperty { get; set; }
        }
    }
}

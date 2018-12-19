using FluentAssertions;
using NUnit.Framework;
using PowerExtensions.Pipeline;
using System;
using System.Collections.Generic;

namespace PowerExtensionTests.Pipeline
{
    [TestFixture]
    public class IndexExtensionsTests
    {
        [Test]
        public void Second_NoConditionAndEnoughElements_ShouldGetResult()
        {
            List<int> elements = new List<int> { 3, 4, 5 };

            int result = elements.Second();

            result.Should().Be(4);
        }

        [Test]
        public void Second_NoConditionAndLessElements_ShouldThrow()
        {
            List<int> elements = new List<int> { 3 };

            Action fail = () => elements.Second();

            fail.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Second_ConditionAndEnoughElements_ShouldGetResult()
        {
            List<int> elements = new List<int> { 3, 4, 5 };

            int result = elements.Second(i => i >= 4);

            result.Should().Be(5);
        }

        [Test]
        public void Second_ConditionAndLessElements_ShouldThrow()
        {
            List<int> elements = new List<int> { 3, 4 };

            Action fail = () => elements.Second(i => i >= 4);

            fail.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Third_NoConditionAndEnoughElements_ShouldGetResult()
        {
            List<int> elements = new List<int> { 3, 4, 5 };

            int result = elements.Third();

            result.Should().Be(5);
        }

        [Test]
        public void Third_NoConditionAndLessElements_ShouldThrow()
        {
            List<int> elements = new List<int> { 3, 4 };

            Action fail = () => elements.Third();

            fail.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Third_ConditionAndEnoughElements_ShouldGetResult()
        {
            List<int> elements = new List<int> { 3, 4, 5, 6 };

            int result = elements.Third(i => i >= 4);

            result.Should().Be(6);
        }

        [Test]
        public void Third_ConditionAndLessElements_ShouldThrow()
        {
            List<int> elements = new List<int> { 3, 4, 5 };

            Action fail = () => elements.Third(i => i >= 4);

            fail.Should().Throw<InvalidOperationException>();
        }
    }
}

using FluentAssertions;
using NUnit.Framework;
using PowerExtensions.Pipeline;
using System.Collections.Generic;
using System.Linq;

namespace PowerExtensionTests.Pipeline
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [Test]
        public void Add_NoValue_ShouldBeStable()
        {
            IEnumerable<int> enumerable = Enumerable.Range(1, 3);

            List<int> result = enumerable.Add().ToList();

            result.Should().BeEquivalentTo(new[] { 1, 2, 3 });
        }

        [Test]
        public void Add_SingleValue_ShouldAdd()
        {
            IEnumerable<int> enumerable = Enumerable.Range(1, 3);

            List<int> result = enumerable.Add(4).ToList();

            result.Should().BeEquivalentTo(new[] { 1, 2, 3, 4 });
        }

        [Test]
        public void Add_MultipleValues_ShouldAdd()
        {
            IEnumerable<int> enumerable = Enumerable.Range(1, 3);

            List<int> result = enumerable.Add(4, 5, 6).ToList();

            result.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5, 6 });
        }

        [Test]
        public void Append_NoValue_ShouldBeStable()
        {
            IEnumerable<int> enumerable = Enumerable.Range(1, 3);

            List<int> result = enumerable.Append().ToList();

            result.Should().BeEquivalentTo(new[] { 1, 2, 3 });
        }

        [Test]
        public void Append_SingleValue_ShouldAppend()
        {
            IEnumerable<int> enumerable = Enumerable.Range(1, 3);

            List<int> result = enumerable.Append(4).ToList();

            result.Should().BeEquivalentTo(new[] { 1, 2, 3, 4 });
        }

        [Test]
        public void Append_MultipleValues_ShouldAppend()
        {
            IEnumerable<int> enumerable = Enumerable.Range(1, 3);

            List<int> result = enumerable.Append(4, 5, 6).ToList();

            result.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5, 6 });
        }

        [Test]
        public void Prepend_NoValue_ShouldBeStable()
        {
            IEnumerable<int> enumerable = Enumerable.Range(1, 3);

            List<int> result = enumerable.Append().ToList();

            result.Should().BeEquivalentTo(new[] { 1, 2, 3 });
        }

        [Test]
        public void Prepent_SingleValue_ShouldPrepend()
        {
            IEnumerable<int> enumerable = Enumerable.Range(1, 3);

            List<int> result = enumerable.Prepend(0).ToList();

            result.Should().BeEquivalentTo(new[] { 0, 1, 2, 3 });
        }

        [Test]
        public void Prepend_MultipleValues_ShouldPrepend()
        {
            IEnumerable<int> enumerable = Enumerable.Range(1, 3);

            List<int> result = enumerable.Append(-2, -1, 0).ToList();

            result.Should().BeEquivalentTo(new[] { -2, -1, 0, 1, 2, 3 });
        }
    }
}

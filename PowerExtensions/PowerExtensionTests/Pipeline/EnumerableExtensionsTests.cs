using FluentAssertions;
using NUnit.Framework;
using PowerExtensions.Pipeline;
using System;
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

        [Test]
        public void CrossJoin_AsTuple_ShouldWork()
        {
            List<int> left = new List<int> { 1, 2, 3 };
            List<string> right = new List<string> { "a", "b" };

            IEnumerable<Tuple<int, string>> result = left.CrossJoin(right);

            result.Should().BeEquivalentTo
            (
                new[]
                {
                    new Tuple<int, string>(1, "a"),
                    new Tuple<int, string>(1, "b"),
                    new Tuple<int, string>(2, "a"),
                    new Tuple<int, string>(2, "b"),
                    new Tuple<int, string>(3, "a"),
                    new Tuple<int, string>(3, "b"),
                }
            );
        }

        [Test]
        public void CrossJoin_WithTransformation_ShouldWork()
        {
            List<int> left = new List<int> { 1, 2, 3 };
            List<string> right = new List<string> { "a", "b" };

            IEnumerable<string> result = left.CrossJoin(right, (l, r) => $"{l}{r}");

            result.Should().BeEquivalentTo(new[] { "1a", "1b", "2a", "2b", "3a", "3b" });
        }

        [Test]
        public void Chunk_ChunkSizeInvalid_ShouldFail([Values(-2, 0)] int chunksize)
        {
            IEnumerable<int> values = Enumerable.Range(1, 10);

            Action fail = () => values.Chunk(chunksize).ToList();

            fail.Should().Throw<ArgumentException>();
        }

        [Test]
        public void Chunk_Empty_ShouldWork()
        {
            IEnumerable<int> values = Enumerable.Empty<int>();

            List<IEnumerable<int>> result = values.Chunk(3).ToList();

            result.Should().HaveCount(0);
        }

        [Test]
        public void Chunk_WithRangeFitting_ShouldWork()
        {
            IEnumerable<int> values = Enumerable.Range(1, 10);

            List<IEnumerable<int>> result = values.Chunk(5).ToList();

            result.Should().HaveCount(2);
            result.First().Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
            result.Second().Should().BeEquivalentTo(new[] { 6, 7, 8, 9, 10 });
        }

        [Test]
        public void Chunk_WithoutRangeFitting_ShouldWork()
        {
            IEnumerable<int> values = Enumerable.Range(1, 10);

            List<IEnumerable<int>> result = values.Chunk(4).ToList();

            result.Should().HaveCount(3);
            result.First().Should().BeEquivalentTo(new[] { 1, 2, 3, 4 });
            result.Second().Should().BeEquivalentTo(new[] { 5, 6, 7, 8 });
            result.Third().Should().BeEquivalentTo(new[] { 9, 10 });
        }
    }
}

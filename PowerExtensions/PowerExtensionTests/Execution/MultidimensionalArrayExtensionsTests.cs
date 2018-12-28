using FluentAssertions;
using NUnit.Framework;
using PowerExtensions.Execution;
using System.Collections.Generic;

namespace PowerExtensionTests.Execution
{
    [TestFixture]
    public class MultidimensionalArrayExtensionsTests
    {
        [Test]
        public void ForEach_WithTwoOnThree_ShouldWork()
        {
            int[,] test = new int[2, 3];
            test[0, 0] = 0;
            test[0, 1] = 1;
            test[0, 2] = 2;
            test[1, 0] = 3;
            test[1, 1] = 4;
            test[1, 2] = 5;

            List<int> result = new List<int>();

            test.ForEach(result.Add);

            result.Should().HaveCount(6);
            result.Should().BeEquivalentTo(new[] { 0, 1, 2, 3, 4, 5 });
        }

        [Test]
        public void ForEachRow_WithTwoOnThree_ShouldWork()
        {
            int[,] test = new int[2, 3];
            test[0, 0] = 0;
            test[0, 1] = 1;
            test[0, 2] = 2;
            test[1, 0] = 3;
            test[1, 1] = 4;
            test[1, 2] = 5;

            List<int[]> result = new List<int[]>();

            test.ForEachRow(result.Add);

            result.Should().HaveCount(2);
            result[0].Should().BeEquivalentTo(new[] { 0, 1, 2 });
            result[1].Should().BeEquivalentTo(new[] { 3, 4, 5 });
        }

        [Test]
        public void ForEachCol_WithTwoOnThree_ShouldWork()
        {
            int[,] test = new int[2, 3];
            test[0, 0] = 0;
            test[0, 1] = 1;
            test[0, 2] = 2;
            test[1, 0] = 3;
            test[1, 1] = 4;
            test[1, 2] = 5;

            List<int[]> result = new List<int[]>();

            test.ForEachCol(result.Add);

            result.Should().HaveCount(3);
            result[0].Should().BeEquivalentTo(new[] { 0, 3 });
            result[1].Should().BeEquivalentTo(new[] { 1, 4 });
            result[2].Should().BeEquivalentTo(new[] { 2, 5 });
        }
    }
}

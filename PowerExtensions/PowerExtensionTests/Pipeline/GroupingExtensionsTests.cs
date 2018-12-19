using FluentAssertions;
using NUnit.Framework;
using PowerExtensions.Pipeline;
using System.Collections.Generic;
using System.Linq;

namespace PowerExtensionTests.Pipeline
{
    [TestFixture]
    public class GroupingExtensionsTests
    {
        [Test]
        public void ToDictionary_EmptyGrouping_ShouldBuildCorrectly()
        {
            IEnumerable<IGrouping<string, User>> group = new List<User>().GroupBy(x => x.FirstName);

            IDictionary<string, IEnumerable<User>> dict = group.ToDictionary();

            dict.Should().BeEmpty();
        }

        [Test]
        public void ToDictionary_FilledGrouping_ShouldBuildCorrectly()
        {
            User johnDoe = new User { FirstName = "John", LastName = "Doe" };
            User robinsonCrusoe = new User { FirstName = "Robinson", LastName = "Crusoe" };
            User johnBonJovi = new User { FirstName = "John", LastName = "Bon Jovi" };
            IEnumerable<IGrouping<string, User>> group = new[] { johnDoe, robinsonCrusoe, johnBonJovi }.GroupBy(x => x.FirstName);

            IDictionary<string, IEnumerable<User>> dict = group.ToDictionary();

            dict.Should().HaveCount(2);
            dict.Should().ContainKey("John");
            dict["John"].Should().HaveCount(2);
            dict["John"].Should().Contain(new[] { johnDoe, johnBonJovi });
            dict.Should().ContainKey("Robinson");
            dict["Robinson"].Should().HaveCount(1);
            dict["Robinson"].Should().Contain(robinsonCrusoe);
        }

        private class User
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }
        }
    }
}

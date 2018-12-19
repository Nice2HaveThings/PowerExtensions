using FluentAssertions;
using NUnit.Framework;
using PowerExtensions.Pipeline;
using System.Collections.Generic;

namespace PowerExtensionTests.Pipeline
{
    [TestFixture]
    public class DictionaryExtensionsTests
    {
        [Test]
        public void GetOrAdd_Empty_ShouldInsertAndReturn()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            int result = dict.GetOrAdd("test", t => t.Length);

            result.Should().Be(4);
            dict.Should().HaveCount(1);
            dict.Should().ContainKey("test");
            dict["test"].Should().Be(4);
        }

        [Test]
        public void GetOrAdd_NewKey_ShouldInsertAndReturn()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>
            {
                { "fubar", 5 }
            };

            int result = dict.GetOrAdd("test", t => t.Length);

            result.Should().Be(4);
            dict.Should().HaveCount(2);
            dict.Should().ContainKey("test");
            dict["test"].Should().Be(4);
        }

        [Test]
        public void GetOrAdd_ExistingKey_ShouldNotInsertAndReturnExisting()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>
            {
                { "fubar", 5 }
            };

            int result = dict.GetOrAdd("fubar", t => 16);

            result.Should().Be(5);
            dict.Should().HaveCount(1);
            dict.Should().ContainKey("fubar");
            dict["fubar"].Should().Be(5);
        }

        [Test]
        public void AddIfMissing_Empty_ShouldAdd()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            dict.AddIfMissing("test", t => t.Length);

            dict.Should().HaveCount(1);
            dict.Should().ContainKey("test");
            dict["test"].Should().Be(4);
        }

        [Test]
        public void AddIfMissing_NewKey_ShouldAdd()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>
            {
                { "fubar", 5 }
            };

            dict.AddIfMissing("test", t => t.Length);
            
            dict.Should().HaveCount(2);
            dict.Should().ContainKey("test");
            dict["test"].Should().Be(4);
        }

        [Test]
        public void AddIfMissing_ExistingKey_ShouldIgnore()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>
            {
                { "fubar", 5 }
            };

            dict.AddIfMissing("fubar", t => 16);
            
            dict.Should().HaveCount(1);
            dict.Should().ContainKey("fubar");
            dict["fubar"].Should().Be(5);
        }
    }
}

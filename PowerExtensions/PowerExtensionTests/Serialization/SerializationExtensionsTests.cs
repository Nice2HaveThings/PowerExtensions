using FluentAssertions;
using NUnit.Framework;
using PowerExtensions.Serialization;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PowerExtensionTests.Serialization
{
    [TestFixture]
    public class SerializationExtensionsTests
    {
        private static TestCaseData[] _serializationValues =
        {
            new TestCaseData(12, "Hallo Welt") { TestName = "Values" },
            new TestCaseData(null, null) { TestName = "NullValues" },
        };

        [Test]
        [TestCaseSource(nameof(_serializationValues))]
        public void GetValue_Used_ShouldWork(int? intVal, string strVal)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MySerializableClass original = new MySerializableClass(intVal, strVal);
            MySerializableClass deserialized;
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, original);
                stream.Position = 0;
                deserialized = (MySerializableClass)formatter.Deserialize(stream);
            }

            deserialized.MyInt.Should().Be(intVal);
            deserialized.MyString.Should().Be(strVal);
        }

        [Serializable]
        private class MySerializableClass : ISerializable
        {
            public int? MyInt { get; }

            public string MyString { get; }

            public MySerializableClass(int? myInt, string myString)
            {
                MyInt = myInt;
                MyString = myString;
            }

            private MySerializableClass(SerializationInfo info, StreamingContext context)
            {
                MyInt = info.GetValue<int?>(nameof(MyInt));
                MyString = info.GetValue<string>(nameof(MyString));
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue(nameof(MyInt), MyInt);
                info.AddValue(nameof(MyString), MyString);
            }
        }
    }
}

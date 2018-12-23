using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PowerExtensions.Serialization
{
    public static class SerializationExtensions
    {
        public static TValue GetValue<TValue>(this SerializationInfo info, string name)
        {
            return (TValue)info.GetValue(name, typeof(TValue));
        }

        public static byte[] GetBytes(this string value)
        {
            return value.GetBytes(new BinaryFormatter());
        }

        public static byte[] GetBytes(this string value, IFormatter formatter)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Can not get bytes of null");
            }

            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, value);
                stream.Position = 0;
                return stream.ToArray();
            }
        }

        public static TValue Deserialize<TValue>(this IFormatter formatter, Stream stream)
        {
            return (TValue) formatter.Deserialize(stream);
        }
    }
}

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PowerExtensions.Serialization
{
    /// <summary>
    /// Extensions for different elements all around serialization
    /// </summary>
    public static class SerializationExtensions
    {
        /// <summary>
        /// Get a value from the <paramref name="info"/> with the <paramref name="name"/>
        /// </summary>
        /// <typeparam name="TValue">Value-Type of the returning value</typeparam>
        /// <param name="info">All stored informations</param>
        /// <param name="name">Name of the returning value</param>
        /// <returns>The serialized value</returns>
        public static TValue GetValue<TValue>(this SerializationInfo info, string name)
        {
            return (TValue)info.GetValue(name, typeof(TValue));
        }

        /// <summary>
        /// Returns a byte representation of the given <paramref name="value"/>
        /// </summary>
        /// <param name="value">Value which should be transformed</param>
        /// <returns>Byte representation of the <paramref name="value"/></returns>
        /// <remarks>The representation is created via <see cref="BinaryFormatter"/></remarks>
        public static byte[] GetBytes(this string value)
        {
            return value.GetBytes(new BinaryFormatter());
        }

        /// <summary>
        /// Returns a byte representation of the given <paramref name="value"/>
        /// </summary>
        /// <param name="value">Value which should be transformed</param>
        /// <param name="formatter">Formatter which is used to create the representation</param>
        /// <returns>Byte representation of the <paramref name="value"/></returns>
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

        /// <summary>
        /// Deserialize a value with the <paramref name="formatter"/> from the given <paramref name="stream"/>
        /// </summary>
        /// <typeparam name="TValue">Value-Type of the deserialized value</typeparam>
        /// <param name="formatter">Formatter which is used to deserialize the value</param>
        /// <param name="stream">Stream where the value is stored</param>
        /// <returns>Deserialized value</returns>
        public static TValue Deserialize<TValue>(this IFormatter formatter, Stream stream)
        {
            return (TValue) formatter.Deserialize(stream);
        }
    }
}

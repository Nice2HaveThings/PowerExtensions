using System;
using System.Data;

namespace PowerExtensions.Querying
{
    /// <summary>
    /// Extensions for <see cref="IDataReader"/>
    /// </summary>
    public static class DataReaderExtensions
    {
        /// <summary>
        /// Returns the value of the <paramref name="reader"/> at the <paramref name="ordinal"/>
        /// </summary>
        /// <typeparam name="TType">Value-Type of the Result</typeparam>
        /// <param name="reader">Reader that is extended</param>
        /// <param name="ordinal">Field-Position of the current reader-element</param>
        /// <returns>Value of the element</returns>
        public static TType GetValue<TType>(this IDataReader reader, int ordinal)
        {
            return (TType) reader.GetValue(ordinal);
        }

        /// <summary>
        /// Returns the value of the <paramref name="reader"/> from the <paramref name="name"/>
        /// </summary>
        /// <typeparam name="TType">Value-Type of the Result</typeparam>
        /// <param name="reader">Reader that is extended</param>
        /// <param name="name">Name of the field in the current reader-element</param>
        /// <returns>Value of the element</returns>
        public static TType GetValue<TType>(this IDataReader reader, string name)
        {
            return reader.GetValue<TType>(reader.GetOrdinal(name));
        }

        /// <summary>
        /// Returns the value of the <paramref name="reader"/> at the <paramref name="ordinal"/> or default value of <typeparamref name="TType"/>
        /// </summary>
        /// <typeparam name="TType">Value-Type of the Result</typeparam>
        /// <param name="reader">Reader that is extended</param>
        /// <param name="ordinal">Field-Position of the current reader-element</param>
        /// <returns>Value of the element or default value</returns>
        public static TType GetValueOrDefault<TType>(this IDataReader reader, int ordinal)
        {
            object value = reader.GetValue(ordinal);
            if(value == null || value == DBNull.Value)
            {
                return default;
            }
            return (TType) value;
        }

        /// <summary>
        /// Returns the value of the <paramref name="reader"/> from the <paramref name="name"/> or default value of <typeparamref name="TType"/>
        /// </summary>
        /// <typeparam name="TType">Value-Type of the Result</typeparam>
        /// <param name="reader">Reader that is extended</param>
        /// <param name="name">Name of the field in the current reader-element</param>
        /// <returns>Value of the element or default value</returns>
        public static TType GetValueOrDefault<TType>(this IDataReader reader, string name)
        {
            return reader.GetValueOrDefault<TType>(reader.GetOrdinal(name));
        }
    }
}

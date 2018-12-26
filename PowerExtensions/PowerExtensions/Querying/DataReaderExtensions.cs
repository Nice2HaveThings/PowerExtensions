using System;
using System.Data;

namespace PowerExtensions.Querying
{
    public static class DataReaderExtensions
    {
        public static TType GetValue<TType>(this IDataReader reader, int ordinal)
        {
            return (TType) reader.GetValue(ordinal);
        }

        public static TType GetValue<TType>(this IDataReader reader, string name)
        {
            return reader.GetValue<TType>(reader.GetOrdinal(name));
        }

        public static TType GetValueOrDefault<TType>(this IDataReader reader, int ordinal)
        {
            object value = reader.GetValue(ordinal);
            if(value == null || value == DBNull.Value)
            {
                return default;
            }
            return (TType) value;
        }

        public static TType GetValueOrDefault<TType>(this IDataReader reader, string name)
        {
            return reader.GetValueOrDefault<TType>(reader.GetOrdinal(name));
        }
    }
}

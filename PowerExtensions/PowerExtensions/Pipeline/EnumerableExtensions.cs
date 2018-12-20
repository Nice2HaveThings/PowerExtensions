using System.Collections.Generic;
using System.Linq;

namespace PowerExtensions.Pipeline
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TValue> Add<TValue>(this IEnumerable<TValue> collection, params TValue[] additionalValues)
        {
            return collection.Concat(additionalValues);
        }

        public static IEnumerable<TValue> Append<TValue>(this IEnumerable<TValue> collection, params TValue[] additionalValues)
        {
            return collection.Add(additionalValues);
        }

        public static IEnumerable<TValue> Prepend<TValue>(this IEnumerable<TValue> collection, params TValue[] additionalValues)
        {
            return additionalValues.Concat(collection);
        }
    }
}

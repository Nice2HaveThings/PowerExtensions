using System.Collections.Generic;
using System.Linq;

namespace PowerExtensions.Pipeline
{
    public static class GroupingExtensions
    {
        public static IDictionary<TKey, IEnumerable<TValue>> ToDictionary<TKey, TValue>(this IEnumerable<IGrouping<TKey, TValue>> values)
        {
            return values.ToDictionary(v => v.Key, v => v.AsEnumerable());
        }
    }
}

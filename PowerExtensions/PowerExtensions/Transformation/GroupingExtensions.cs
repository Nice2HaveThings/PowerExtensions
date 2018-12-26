using System.Collections.Generic;
using System.Linq;

namespace PowerExtensions.Transformation
{
    /// <summary>
    /// Extensions for <see cref="IGrouping{K,V}"/>
    /// </summary>
    public static class GroupingExtensions
    {
        /// <summary>
        /// Creates a default dictionary of the <paramref name="collection"/>
        /// </summary>
        /// <typeparam name="TKey">Key-Type of the collection</typeparam>
        /// <typeparam name="TValue">Value-Type of the collection</typeparam>
        /// <param name="collection">Collection which should be transformated</param>
        /// <returns>Created dictionary</returns>
        public static IDictionary<TKey, IEnumerable<TValue>> ToDictionary<TKey, TValue>(this IEnumerable<IGrouping<TKey, TValue>> collection)
        {
            return collection.ToDictionary(v => v.Key, v => v.AsEnumerable());
        }
    }
}

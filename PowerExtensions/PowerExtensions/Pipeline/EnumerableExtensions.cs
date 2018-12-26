using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerExtensions.Pipeline
{
    /// <summary>
    /// Extensions for <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Adds some values to the collection
        /// </summary>
        /// <typeparam name="TValue">Value-Type of the collection</typeparam>
        /// <param name="collection">Collection which is extended</param>
        /// <param name="additionalValues">Values that are added</param>
        /// <returns>Collection with the added values</returns>
        public static IEnumerable<TValue> Add<TValue>(this IEnumerable<TValue> collection, params TValue[] additionalValues)
        {
            return collection.Concat(additionalValues);
        }

        /// <summary>
        /// Adds some values at the end of the collection
        /// </summary>
        /// <typeparam name="TValue">Value-Type of the collection</typeparam>
        /// <param name="collection">Collection that is extended</param>
        /// <param name="additionalValues">Values that are added</param>
        /// <returns>Collection with the added values</returns>
        public static IEnumerable<TValue> Append<TValue>(this IEnumerable<TValue> collection, params TValue[] additionalValues)
        {
            return collection.Add(additionalValues);
        }

        /// <summary>
        /// Adds some values at the beginning of the collection
        /// </summary>
        /// <typeparam name="TValue">Value-Type of the collection</typeparam>
        /// <param name="collection">Collection that is extended</param>
        /// <param name="additionalValues">Values that are added</param>
        /// <returns>Collection with the added values</returns>
        public static IEnumerable<TValue> Prepend<TValue>(this IEnumerable<TValue> collection, params TValue[] additionalValues)
        {
            return additionalValues.Concat(collection);
        }

        /// <summary>
        /// Returns an collection of all combinations of the given collections
        /// </summary>
        /// <typeparam name="TValueLeft">Value-Type of the left collection</typeparam>
        /// <typeparam name="TValueRight">Value-Type of the right collection</typeparam>
        /// <param name="collection">Collection that is extended</param>
        /// <param name="collectionToJoin">Collection that would be joined</param>
        /// <returns>Collection of all combinations as Tuples</returns>
        public static IEnumerable<Tuple<TValueLeft, TValueRight>> CrossJoin<TValueLeft, TValueRight>(this IEnumerable<TValueLeft> collection, IEnumerable<TValueRight> collectionToJoin)
        {
            return collection.CrossJoin(collectionToJoin, (l, r) => new Tuple<TValueLeft, TValueRight>(l, r));
        }

        /// <summary>
        /// Returns a collection of all combinations of the given collections
        /// </summary>
        /// <typeparam name="TValueLeft">Value-Type of the left collection</typeparam>
        /// <typeparam name="TValueRight">Value-Type of the right collection</typeparam>
        /// <typeparam name="TResult">Value-Type of the returning collection</typeparam>
        /// <param name="collection">Collection that is extended</param>
        /// <param name="collectionToJoin">Collection that would be joined</param>
        /// <param name="transformation">Provider for the transformation from the two collections in the returning-collection</param>
        /// <returns>Collection of all combinations</returns>
        public static IEnumerable<TResult> CrossJoin<TValueLeft, TValueRight, TResult>(this IEnumerable<TValueLeft> collection, IEnumerable<TValueRight> collectionToJoin, Func<TValueLeft, TValueRight, TResult> transformation)
        {
            foreach(TValueLeft left in collection)
            {
                foreach(TValueRight right in collectionToJoin)
                {
                    yield return transformation(left, right);
                }
            }
        }

        /// <summary>
        /// Chunks an collection into several parts with the max size of <paramref name="chunkSize"/>
        /// </summary>
        /// <typeparam name="TValue">Value-Type of the collection</typeparam>
        /// <param name="collection">Collection that is extended</param>
        /// <param name="chunkSize">Max-Size of the Chunks</param>
        /// <returns>Collection of all resulting subcollections</returns>
        public static IEnumerable<IEnumerable<TValue>> Chunk<TValue>(this IEnumerable<TValue> collection, int chunkSize)
        {
            if(chunkSize < 1)
            {
                throw new ArgumentException("chunksize must be greater 0");
            }

            int count = 0;
            List<TValue> subResult = new List<TValue>();
            using (IEnumerator<TValue> enumerator = collection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    subResult.Add(enumerator.Current);
                    if (++count == chunkSize)
                    {
                        yield return subResult;
                        count = 0;
                        subResult = new List<TValue>();
                    }
                }
            }

            if(subResult.Count() > 0)
            {
                yield return subResult;
            }
        }

        /// <summary>
        /// Combines the Linq-Methods of Select and ToList
        /// </summary>
        /// <typeparam name="TType">Value-Type of the collection</typeparam>
        /// <typeparam name="TResult">Value-Type of the result</typeparam>
        /// <param name="collection">Collection that is extended</param>
        /// <param name="transformation">Provides the transformation of the Values from <typeparamref name="TType"/> into <typeparamref name="TResult"/></param>
        /// <returns>Selected collection as list</returns>
        public static List<TResult> SelectList<TType, TResult>(this IEnumerable<TType> collection, Func<TType, TResult> transformation)
        {
            return collection.Select(transformation).ToList();
        }
    }
}

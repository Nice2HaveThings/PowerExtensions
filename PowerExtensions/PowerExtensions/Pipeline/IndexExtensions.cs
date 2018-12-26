using System;
using System.Collections.Generic;

namespace PowerExtensions.Pipeline
{
    /// <summary>
    /// Extensions for Index-Methods of <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class IndexExtensions
    {
        /// <summary>
        /// Returns the second element of the <paramref name="collection"/>
        /// </summary>
        /// <typeparam name="TElement">Value-Type of the collection</typeparam>
        /// <param name="collection">Collection that is extended</param>
        /// <returns>Second element of the collection</returns>
        public static TElement Second<TElement>(this IEnumerable<TElement> collection)
        {
            return collection.Second(e => true);
        }

        /// <summary>
        /// Gives the second element of the <paramref name="collection"/>
        /// </summary>
        /// <typeparam name="TElement">Value-Type of the collection</typeparam>
        /// <param name="collection">Collection that is extended</param>
        /// <param name="condition">Condition which the values must fullfill</param>
        /// <returns>Second element of the collection</returns>
        public static TElement Second<TElement>(this IEnumerable<TElement> collection, Predicate<TElement> condition)
        {
            if(collection.TryGetElementAtIndex(condition, 2, out TElement result))
            {
                return result;
            }

            throw new InvalidOperationException("Not enough elements in collection");
        }

        /// <summary>
        /// Gives the second element of the <paramref name="collection"/> or the default value of <typeparamref name="TElement"/>
        /// </summary>
        /// <typeparam name="TElement">Value-Type of the collection</typeparam>
        /// <param name="collection">Collection that is extended</param>
        /// <returns>Second element of the collection or default value</returns>
        public static TElement SecondOrDefault<TElement>(this IEnumerable<TElement> collection)
        {
            return collection.SecondOrDefault(e => true);
        }

        /// <summary>
        /// Gives the second element of the <paramref name="collection"/> or the default value of <typeparamref name="TElement"/>
        /// </summary>
        /// <typeparam name="TElement">Value-Type of the collection</typeparam>
        /// <param name="collection">Collection that is extended</param>
        /// <param name="condition">Condition which the values must fullfill</param>
        /// <returns>Second element of the collection or default value</returns>
        public static TElement SecondOrDefault<TElement>(this IEnumerable<TElement> collection, Predicate<TElement> condition)
        {
            collection.TryGetElementAtIndex(condition, 2, out TElement result);
            return result;
        }

        /// <summary>
        /// Gives the third element of the <paramref name="collection"/>
        /// </summary>
        /// <typeparam name="TElement">Value-Type of the collection</typeparam>
        /// <param name="collection">Collection that is extended</param>
        /// <returns>Third element of the collection</returns>
        public static TElement Third<TElement>(this IEnumerable<TElement> collection)
        {
            return collection.Third(e => true);
        }

        /// <summary>
        /// Gives the third element of the <paramref name="collection"/>
        /// </summary>
        /// <typeparam name="TElement">Value-Type of the collection</typeparam>
        /// <param name="collection">Collection that is extended</param>
        /// <param name="condition">Condition which the values must fullfill</param>
        /// <returns>Third element of the collection</returns>
        public static TElement Third<TElement>(this IEnumerable<TElement> collection, Predicate<TElement> condition)
        {
            if(collection.TryGetElementAtIndex(condition, 3, out TElement result))
            {
                return result;
            }

            throw new InvalidOperationException("Not enough elements in collection");
        }

        /// <summary>
        /// Gives the second element of the <paramref name="collection"/> or default value of <typeparamref name="TElement"/>
        /// </summary>
        /// <typeparam name="TElement">Value-Type of the collection</typeparam>
        /// <param name="collection">Collection that is extended</param>
        /// <returns>Third element of the collection or default value</returns>
        public static TElement ThirdOrDefault<TElement>(this IEnumerable<TElement> collection)
        {
            return collection.ThirdOrDefault(e => true);
        }

        /// <summary>
        /// Gives the third element of the <paramref name="collection"/> or default value of <typeparamref name="TElement"/>
        /// </summary>
        /// <typeparam name="TElement">Value-Type of the collection</typeparam>
        /// <param name="collection">Collection that is extended</param>
        /// <param name="condition">Condition which the values must fullfill</param>
        /// <returns>Third element of the collection</returns>
        public static TElement ThirdOrDefault<TElement>(this IEnumerable<TElement> collection, Predicate<TElement> condition)
        {
            collection.TryGetElementAtIndex(condition, 3, out TElement result);
            return result;
        }

        private static bool TryGetElementAtIndex<TElement>(this IEnumerable<TElement> collection, Predicate<TElement> condition, int index, out TElement element)
        {
            int matches = 0;
            foreach(TElement ele in collection)
            {
                if(condition(ele) && ++matches == index)
                {
                    element = ele;
                    return true;
                }
            }

            element = default;
            return false;
        }
    }
}

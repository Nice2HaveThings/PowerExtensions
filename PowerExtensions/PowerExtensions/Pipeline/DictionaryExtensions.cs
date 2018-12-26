using System;
using System.Collections.Generic;

namespace PowerExtensions.Pipeline
{
    /// <summary>
    /// Extensions for <see cref="IDictionary{TKey, TValue}"/>
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Get the Value for the given <paramref name="key"/> or add and return an entry to the dictionary, if the key does not exist.
        /// </summary>
        /// <typeparam name="TKey">Key-Type of the dictionary</typeparam>
        /// <typeparam name="TValue">Value-Type of the dictionary</typeparam>
        /// <param name="dictionary">Dicitionary which is extended</param>
        /// <param name="key">Key to search for</param>
        /// <param name="valueProvider">Provides the value in the add-szenario</param>
        /// <returns>The existing or created value for the <paramref name="key"/></returns>
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueProvider)
        {
            if(!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, valueProvider(key));
            }

            return dictionary[key];
        }

        /// <summary>
        /// Add an entry to the <paramref name="dictionary"/> if the key does not exist
        /// </summary>
        /// <typeparam name = "TKey">Key-Type of the dictionary</typeparam>
        /// <typeparam name="TValue">Value-Type of the dictionary</typeparam>
        /// <param name="dictionary">Dicitionary which is extended</param>
        /// <param name="key">Key to search for</param>
        /// <param name="valueProvider">Provides the value in the add-szenario</param>
        public static void AddIfMissing<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueProvider)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, valueProvider(key));
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace PowerExtensions.Pipeline
{
    public static class DictionaryExtensions
    {
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue> valueProvider)
        {
            if(!dict.ContainsKey(key))
            {
                dict.Add(key, valueProvider(key));
            }

            return dict[key];
        }

        public static void AddIfMissing<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue> valueProvider)
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, valueProvider(key));
            }
        }
    }
}

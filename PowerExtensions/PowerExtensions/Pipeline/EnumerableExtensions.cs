using System;
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

        public static IEnumerable<Tuple<TValueLeft, TValueRight>> CrossJoin<TValueLeft, TValueRight>(this IEnumerable<TValueLeft> values, IEnumerable<TValueRight> valuesToJoin)
        {
            return values.CrossJoin(valuesToJoin, (l, r) => new Tuple<TValueLeft, TValueRight>(l, r));
        }

        public static IEnumerable<TResult> CrossJoin<TValueLeft, TValueRight, TResult>(this IEnumerable<TValueLeft> values, IEnumerable<TValueRight> valuesToJoin, Func<TValueLeft, TValueRight, TResult> transformation)
        {
            foreach(TValueLeft left in values)
            {
                foreach(TValueRight right in valuesToJoin)
                {
                    yield return transformation(left, right);
                }
            }
        }

        public static IEnumerable<IEnumerable<TValue>> Chunk<TValue>(this IEnumerable<TValue> values, int chunkSize)
        {
            if(chunkSize < 1)
            {
                throw new ArgumentException("chunksize must be greater 0");
            }

            int count = 0;
            List<TValue> subResult = new List<TValue>();
            using (IEnumerator<TValue> enumerator = values.GetEnumerator())
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

        public static List<TResult> SelectList<TType, TResult>(this IEnumerable<TType> values, Func<TType, TResult> transformation)
        {
            return values.Select(transformation).ToList();
        }
    }
}

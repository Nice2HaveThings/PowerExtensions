using System;
using System.Collections.Generic;

namespace PowerExtensions.Pipeline
{
    public static class IndexExtensions
    {
        public static TElement Second<TElement>(this IEnumerable<TElement> elements)
        {
            return elements.Second(e => true);
        }

        public static TElement Second<TElement>(this IEnumerable<TElement> elements, Predicate<TElement> condition)
        {
            if(elements.TryGetElementAtIndex(condition, 2, out TElement result))
            {
                return result;
            }

            throw new InvalidOperationException("Not enough elements in collection");
        }

        public static TElement SecondOrDefault<TElement>(this IEnumerable<TElement> elements)
        {
            return elements.SecondOrDefault(e => true);
        }

        public static TElement SecondOrDefault<TElement>(this IEnumerable<TElement> elements, Predicate<TElement> condition)
        {
            elements.TryGetElementAtIndex(condition, 2, out TElement result);
            return result;
        }

        public static TElement Third<TElement>(this IEnumerable<TElement> elements)
        {
            return elements.Third(e => true);
        }

        public static TElement Third<TElement>(this IEnumerable<TElement> elements, Predicate<TElement> condition)
        {
            if(elements.TryGetElementAtIndex(condition, 3, out TElement result))
            {
                return result;
            }

            throw new InvalidOperationException("Not enough elements in collection");
        }

        public static TElement ThirdOrDefault<TElement>(this IEnumerable<TElement> elements)
        {
            return elements.ThirdOrDefault(e => true);
        }

        public static TElement ThirdOrDefault<TElement>(this IEnumerable<TElement> elements, Predicate<TElement> condition)
        {
            elements.TryGetElementAtIndex(condition, 3, out TElement result);
            return result;
        }

        private static bool TryGetElementAtIndex<TElement>(this IEnumerable<TElement> elements, Predicate<TElement> condition, int index, out TElement element)
        {
            int matches = 0;
            foreach(TElement ele in elements)
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

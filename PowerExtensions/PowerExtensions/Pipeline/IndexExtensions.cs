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
            return elements.GetElementAtIndex(condition, 2);
        }

        public static TElement Third<TElement>(this IEnumerable<TElement> elements)
        {
            return elements.Third(e => true);
        }

        public static TElement Third<TElement>(this IEnumerable<TElement> elements, Predicate<TElement> condition)
        {
            return elements.GetElementAtIndex(condition, 3);
        }

        private static TElement GetElementAtIndex<TElement>(this IEnumerable<TElement> elements, Predicate<TElement> condition, int index)
        {
            int matches = 0;
            foreach(TElement element in elements)
            {
                if(condition(element) && ++matches == index)
                {
                    return element;
                }
            }

            throw new InvalidOperationException("Not enough elements in collection");
        }
    }
}

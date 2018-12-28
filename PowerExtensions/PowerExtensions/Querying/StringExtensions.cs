using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerExtensions.Querying
{
    /// <summary>
    /// Extensions for quering <see cref="string"/>s
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Determined that the <paramref name="substring"/> occurs on <paramref name="str"/> at <paramref name="index"/>
        /// </summary>
        /// <param name="str">string that is searched</param>
        /// <param name="substring">substring that is seeked</param>
        /// <param name="index">index where the substring is expected</param>
        /// <returns><see langword="true"/> if the substring is found on the expected position</returns>
        public static bool ContainsAtIndex(this string str, string substring, int index)
        {
            if(str == null || str.Length < (index + substring.Length))
            {
                return false;
            }

            return string.Concat(str.Skip(index)).StartsWith(substring);
        }

        /// <summary>
        /// Determined that the <paramref name="substring"/> occurs on <paramref name="str"/> at <paramref name="index"/> or above
        /// </summary>
        /// <param name="str">string that is searched</param>
        /// <param name="substring">substring that is seeked</param>
        /// <param name="index">minimum index where the substring is expected</param>
        /// <returns><see langword="true"/> if the substring is found in the expected range</returns>
        public static bool ContainsFromIndex(this string str, string substring, int index)
        {
            if (str == null || str.Length < (index + substring.Length))
            {
                return false;
            }

            return string.Concat(str.Skip(index)).Contains(substring);
        }

        /// <summary>
        /// Determined that the <paramref name="substring"/> occurs on <paramref name="str"/> at <paramref name="index"/> or below
        /// </summary>
        /// <param name="str">string that is searched</param>
        /// <param name="substring">substring that is seeked</param>
        /// <param name="index">maximum index where the substring is expected</param>
        /// <returns><see langword="true"/> if the substring is found in the expected range</returns>
        public static bool ContainsUntilIndex(this string str, string substring, int index)
        {
            if (str == null || str.Length < substring.Length || str.Length < (index + 1))
            {
                return false;
            }

            return string.Concat(str.Take(index + 1)).Contains(substring);
        }
    }
}

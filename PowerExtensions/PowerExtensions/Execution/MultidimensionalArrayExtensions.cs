using System;
using System.Collections.Generic;

namespace PowerExtensions.Execution
{
    /// <summary>
    /// Extensions for multidimensional arrays
    /// </summary>
    public static class MultidimensionalArrayExtensions
    {
        /// <summary>
        /// Executes the <paramref name="action"/> for each element of the array
        /// </summary>
        /// <typeparam name="T">Value-Typ of the array</typeparam>
        /// <param name="array">Array which is extended</param>
        /// <param name="action">Action that should be executed for the elements</param>
        public static void ForEach<T>(this T[,] array, Action<T> action)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                List<T> subArr = new List<T>();
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    action(array[i, j]);
                }
            }
        }

        /// <summary>
        /// Executes the <paramref name="rowAction"/> for each row of the array
        /// </summary>
        /// <typeparam name="T">Value-Typ of the array</typeparam>
        /// <param name="array">Array which is extended</param>
        /// <param name="rowAction">Action that should be executed for the rows</param>
        public static void ForEachRow<T>(this T[,] array, Action<T[]> rowAction)
        {
            for(int i = 0; i < array.GetLength(0); i++)
            {
                List<T> subArr = new List<T>();
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    subArr.Add(array[i, j]);
                }
                rowAction(subArr.ToArray());
            }
        }

        /// <summary>
        /// Executes the <paramref name="colAction"/> for each col of the array
        /// </summary>
        /// <typeparam name="T">Value-Typ of the array</typeparam>
        /// <param name="array">Array which is extended</param>
        /// <param name="colAction">Action that should be executed for the cols</param>
        public static void ForEachCol<T>(this T[,] array, Action<T[]> colAction)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                List<T> subArr = new List<T>();
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    subArr.Add(array[j, i]);
                }
                colAction(subArr.ToArray());
            }
        }
    }
}

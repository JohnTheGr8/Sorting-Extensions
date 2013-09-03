using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingExtensions
{
    public static class SortingExtensions
    {
        /// <summary>
        /// Sort the given list with the Bubble Sort Algorithm
        /// </summary>
        /// <typeparam name="T">element type, must be IComparable</typeparam>
        /// <param name="array">The list of elements to sort</param>
        /// <returns>The sorted list</returns>
        public static List<T> BubbleSort<T> (this List<T> array) where T : IComparable
        {
            for (int i=0; i < array.Count(); i++)
            {
                bool swapped = false;
                for (int j = 0; j < array.Count - 1; j++)
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        array = array.Swap(j, j + 1);
                        swapped = true;
                    }                
                if (!swapped) break;                
            }
            // Return sorted array
            return array;
        }

        /// <summary>
        /// Sort the given list with the Insertion Sort Algorithm
        /// </summary>
        /// <typeparam name="T">element type, must be IComparable</typeparam>
        /// <param name="array">The list of elements to sort</param>
        /// <returns>The sorted list</returns>
        public static List<T> InsertionSort<T> (this List<T> array) where T : IComparable
        {
            for (int i = 1; i < array.Count; i++)
                for (int k = i; k > 0 && array[k].CompareTo(array[k - 1]) < 0; k--)
                    array = array.Swap(k, k - 1);
            return array;
        }

        /// <summary>
        /// Sort the given list with the Selection Sort Algorithm
        /// </summary>
        /// <typeparam name="T">element type, must be IComparable</typeparam>
        /// <param name="array">The list of elements to sort</param>
        /// <returns>The sorted list</returns>
        public static List<T> SelectionSort<T> (this List<T> array) where T : IComparable
        {
            for (int i=0; i < array.Count; i++)
            {
                int k = i;
                for (int j = i + 1; j < array.Count; j++)                
                    if (array[j].CompareTo(array[k]) < 0)
                        k = j;                                   
                array = array.Swap(i, k);
            }
            // Return sorted array
            return array;
        }

        /// <summary>
        /// Sort the given list with the Heap Sort Algorithm
        /// </summary>
        /// <typeparam name="T">element type, must be IComparable</typeparam>
        /// <param name="array">The list of elements to sort</param>
        /// <returns>The sorted list</returns>
        public static List<T> HeapSort<T>(this List<T> array) where T : IComparable
        {
            for (int i = array.Count / 2; i >= 0; i--)
                array = array.Sink(i, array.Count - 1);

            for (int i = 0; i < array.Count; i++)
            {
                array = array.Swap(0, array.Count - i - 1);
                array = array.Sink(0, array.Count - i - 2);
            }

            // Return sorted array
            return array;
        }

        /// <summary>
        /// Sort the given list with the Merge Sort Algorithm
        /// </summary>
        /// <typeparam name="T">element type, must be IComparable</typeparam>
        /// <param name="array">The list of elements to sort</param>
        /// <returns>The sorted list</returns>
        public static List<T> MergeSort<T>(this List<T> array) where T : IComparable
        {
            if (array.Count == 1) return array;

            int m = array.Count / 2;

            var left  = MergeSort<T>(array.GetRange(0, m));
            var right = MergeSort<T>(array.GetRange(m, array.Count - m));
            array = left.Concat(right).ToList();

            var b = array.GetRange(0, m);
            int i = 0, j = m, k = 0;
            while (i < m && j < array.Count)
                array[k++] = (array[j].CompareTo(b[i]) < 0) ? array[j++] : b[i++];
            while (i < m)
                array[k++] = b[i++];
            
            // Return sorted array
            return array;
        }

        /// <summary>
        /// Swap two elements in the given list
        /// </summary>
        /// <typeparam name="T">element type, can be anything</typeparam>
        /// <param name="array">The list to update</param>
        /// <param name="e1">index of first element</param>
        /// <param name="e2">index of second element</param>
        /// <returns>a new list with the elements swapped</returns>
        public static List<T> Swap<T>(this List<T> array, int e1, int e2)
        {
            var temp = array[e1];
            array[e1] = array[e2];
            array[e2] = temp;

            return array;
        }

        /// <summary>
        /// Sink function used in the Heap Sort Method
        /// </summary>
        internal static List<T> Sink<T>(this List<T> array, int i, int n) where T : IComparable
        {
            int lc = 2 * i;
            if (lc > n) return array;

            int rc = lc + 1;
            int mc = (rc > n) ? lc : ((array[lc].CompareTo(array[rc]) > 0) ? lc : rc);
            if (array[i].CompareTo(array[mc]) >= 0)
                return array;
            array = array.Swap(i, mc);
            return array.Sink<T>(mc, n);
        }
    }

    public static class SortingByKeyExtensions
    {
        /// <summary>
        /// Sort the given list with the Bubble Sort Algorithm
        /// </summary>
        /// <typeparam name="T">element type</typeparam>
        /// <typeparam name="TResult">element's key by which to sort, must be IComparable</typeparam>
        /// <param name="array">The list of elements to sort</param>
        /// <param name="keySelector">Sort the elements according to a key</param>
        /// <returns>The sorted list</returns>
        public static List<T> BubbleSort<T, TResult>(this List<T> array, Func<T, TResult> keySelector) where TResult : IComparable
        {
            for (int i = 0; i < array.Count(); i++)
            {
                bool swapped = false;
                for (int j = 0; j < array.Count - 1; j++)
                    if (keySelector(array[j]).CompareTo(keySelector(array[j + 1])) > 0)
                    {
                        array = array.Swap(j, j + 1);
                        swapped = true;
                    }
                if (!swapped) break;
            }
            // Return sorted array
            return array;
        }

        /// <summary>
        /// Sort the given list with the Insertion Sort Algorithm
        /// </summary>
        /// <typeparam name="T">element type</typeparam>
        /// <typeparam name="TResult">element's key by which to sort, must be IComparable</typeparam>
        /// <param name="array">The list of elements to sort</param>
        /// <param name="keySelector">Sort the elements according to a key</param>
        /// <returns>The sorted list</returns>
        public static List<T> InsertionSort<T, TResult>(this List<T> array, Func<T, TResult> keySelector) where TResult : IComparable
        {
            for (int i = 1; i < array.Count; i++)
                for (int k = i; k > 0 && keySelector(array[k]).CompareTo(keySelector(array[k - 1])) < 0; k--)
                    array = array.Swap(k, k - 1);
            return array;
        }

        /// <summary>
        /// Sort the given list with the Selection Sort Algorithm
        /// </summary>
        /// <typeparam name="T">element type</typeparam>
        /// <typeparam name="TResult">element's key by which to sort, must be IComparable</typeparam>
        /// <param name="array">The list of elements to sort</param>
        /// <param name="keySelector">Sort the elements according to a key</param>
        /// <returns>The sorted list</returns>
        public static List<T> SelectionSort<T, TResult>(this List<T> array, Func<T, TResult> keySelector) where TResult : IComparable
        {
            for (int i = 0; i < array.Count; i++)
            {
                int k = i;
                for (int j = i + 1; j < array.Count; j++)
                    if (keySelector(array[j]).CompareTo(keySelector(array[k])) < 0)
                        k = j;
                array = array.Swap(i, k);
            }
            // Return sorted array
            return array;
        }


        /// <summary>
        /// Sort the given list with the Heap Sort Algorithm
        /// </summary>
        /// <typeparam name="T">element type</typeparam>
        /// <typeparam name="TResult">element's key by which to sort, must be IComparable</typeparam>
        /// <param name="array">The list of elements to sort</param>
        /// <param name="keySelector">Sort the elements according to a key</param>
        /// <returns>The sorted list</returns>
        public static List<T> HeapSort<T, TResult>(this List<T> array, Func<T, TResult> keySelector) where TResult : IComparable
        {
            for (int i = array.Count / 2; i >= 0; i--)
                array = array.Sink(i, array.Count - 1, keySelector);

            for (int i = 0; i < array.Count; i++)
            {
                array = array.Swap(0, array.Count - i - 1);
                array = array.Sink(0, array.Count - i - 2, keySelector);
            }

            // Return sorted array
            return array;
        }

        /// <summary>
        /// Sort the given list with the Merge Sort Algorithm
        /// </summary>
        /// <typeparam name="T">element type</typeparam>
        /// <typeparam name="TResult">element's key by which to sort, must be IComparable</typeparam>
        /// <param name="array">The list of elements to sort</param>
        /// <param name="keySelector">Sort the elements according to a key</param>
        /// <returns>The sorted list</returns>
        public static List<T> MergeSort<T, TResult>(this List<T> array, Func<T, TResult> keySelector) where TResult : IComparable
        {
            if (array.Count == 1) return array;

            int m = array.Count / 2;

            var left  = MergeSort<T, TResult> (array.GetRange(0, m), keySelector);
            var right = MergeSort<T, TResult> (array.GetRange(m, array.Count - m), keySelector);
            array = left.Concat(right).ToList();

            var b = array.GetRange(0, m);
            int i = 0, j = m, k = 0;
            while (i < m && j < array.Count)
                array[k++] = (keySelector(array[j]).CompareTo(keySelector(b[i])) < 0) ? array[j++] : b[i++];
            while (i < m)
                array[k++] = b[i++];
             
            // Return sorted array
            return array;
        }

        /// <summary>
        /// Sink function used in the Heap Sort Method
        /// </summary>
        internal static List<T> Sink<T, TResult>(this List<T> array, int i, int n, Func<T, TResult> keySelector) where TResult : IComparable
        {
            int lc = 2 * i;
            if (lc > n) return array;

            int rc = lc + 1;
            int mc = (rc > n) ? lc : ((keySelector(array[lc]).CompareTo(keySelector(array[rc])) > 0) ? lc : rc);
            if (keySelector(array[i]).CompareTo(keySelector(array[mc])) >= 0)
                return array;
            array = array.Swap(i, mc);
            return array.Sink<T, TResult>(mc, n, keySelector);
        }
    }
}

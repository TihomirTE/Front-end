using System;

namespace _04.Sort_algorithms
{
    public class SortAlgorithm
    {
        public static void Main()
        {
            var intArray = new int[] { 5, 3, 9, 1, 8, 2, 7, 6, 4 };
            InsertionSort(intArray);

            var arr = new int[] { 5, 3, 9, 1, 8, 2, 7, 6, 4 };
            SelectionSort(arr);

            var arrQuick = new int[] { 5, 3, 9, 1, 8, 2, 7, 6, 4 };
            QuickSort(arrQuick, 0, arrQuick.Length - 1);
        }

        // Sorting algorithms
        private static void InsertionSort<T>(T[] arr)
            where T : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                var value = arr[i];

                while ((j > 0) && (arr[j - 1].CompareTo(value) > 0))
                {
                    arr[j] = arr[j - 1];
                    j -= 1;
                }

                arr[j] = value;
            }

            Console.WriteLine("Insertion sort: " + string.Join(" ", arr));
        }

        private static void SelectionSort<T>(T[] arr)
            where T : IComparable
        {
            int currentPosition = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                var minValue = arr[i];

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(minValue) < 0)
                    {
                        minValue = arr[j];
                        currentPosition = j;
                    }
                }

                if (i != currentPosition && minValue.CompareTo(arr[i]) < 0)
                {
                    var swapVariable = arr[i];
                    arr[i] = arr[currentPosition];
                    arr[currentPosition] = swapVariable;
                }
            }

            Console.WriteLine("Selection sort: " + string.Join(" ", arr));
        }

        private static void QuickSort<T>(T[] array, int smaller, int bigger)
            where T : IComparable
        {
            int left = smaller;
            int right = bigger;
            T pivot = array[(smaller + bigger) / 2];

            while (left <= right)
            {
                while (array[left].CompareTo(pivot) < 0)
                {
                    left++;
                }

                while (array[right].CompareTo(pivot) > 0)
                {
                    right--;
                }

                if (left <= right)
                {
                    T swapVariable = array[left];
                    array[left] = array[right];
                    array[right] = swapVariable;

                    left++;
                    right--;
                }

                if (smaller < right)
                {
                    QuickSort<T>(array, smaller, right);
                }

                if (left < bigger)
                {
                    QuickSort<T>(array, left, bigger);
                }
            }

            Console.WriteLine("Quick sort: " + string.Join(" ", array));
        }
    }
}

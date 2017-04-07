using System;
using System.Diagnostics;

public class AssertionsHomework
{
    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        // comment these tests in order to pass the program
        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    public static void SelectionSort<T>(T[] arr) 
        where T : IComparable<T>
    {
        Debug.Assert(IsArrayValid(arr, 2), "Array should contain at least 2 elements in order to be sorted");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }

    public static int BinarySearch<T>(T[] arr, T value) 
        where T : IComparable<T>
    {
        Debug.Assert(IsArrayValid(arr, 1), "Array can not be null or empty");
        Debug.Assert(IsArraySorted(arr), "Binary search should work only with sorted array");
        Debug.Assert(value != null, "value should not be null");

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(IsArrayValid(arr, 1), "Array can not be null or empty");
        Debug.Assert(startIndex <= endIndex, "startIndex can not be bigger than endIndex");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        Debug.Assert(x != null, "x should not be null!");
        Debug.Assert(y != null, "y should not be null!");

        T oldX = x;
        x = y;
        y = oldX;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(startIndex <= endIndex, "startIndex can not be bigger than endIndex");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    // Assertions methods
    private static bool IsArrayValid<T>(T[] arr, int arrayLength) 
        where T : IComparable<T>
    {
        if (arr == null || arr.Length < arrayLength)
        {
            return false;
        }

        return true;
    }

    private static bool IsArraySorted<T>(T[] arr)
        where T : IComparable<T>
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            // check for sorted array
            if (arr[i].CompareTo(arr[i + 1]) > 0)
            {
                return false;
            }
        }

        return true;
    }
}

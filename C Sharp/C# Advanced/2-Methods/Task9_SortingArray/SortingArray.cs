using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9_SortingArray
{
    class SortingArray
    {
        static void Main()
        {
            var num = Console.ReadLine();
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            SortArray(numbers);
        }
        static void SortArray(int[] arr)
        {
            // Bubble Sorting Method
            int temp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}

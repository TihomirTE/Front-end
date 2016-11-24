using System;
using System.Linq;

namespace Task8_NumberAsArray
{
    class NumberAsArray
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int min = Math.Min(nums[0], nums[1]);
            CalculateSum(min, arr1, arr2);
        }

        private static void CalculateSum(int minLenght, int[] arr1, int[] arr2)
        {
            int transfer = 0; // value (if the sum > 10) add one to the right position
            int current = 0;
            for (int i = 0; i < minLenght; i++) // Take the lenght of the smaller array
            {
                current = arr1[i] + arr2[i] + transfer; // Sum every position seperately
                if (current > 9)
                {
                    current = current - 10;
                    transfer = 1;
                }
                else
                {
                    transfer = 0;
                }
                Console.Write(current + " ");
            }

            // if one of the array is bigger than the other
            if (arr1.Length > arr2.Length) 
            {
                CalculateTheRest(arr1, arr2, transfer);
            }
            else if (arr2.Length > arr1.Length)
            {
                CalculateTheRest(arr2, arr1, transfer);
            }
            // if the lenght of the arrays are the same && transfer == 1
            else if (transfer == 1) 
            {
                Console.Write(1);
            }
            Console.WriteLine();
        }

        private static void CalculateTheRest(int[] arrBigger, int[] arrSmaller, int transfer)
        {
            for (int i = arrSmaller.Length; i < arrBigger.Length; i++) // take the value of the bigger array
            {
                if (i == arrSmaller.Length) // include the transfer in the calculations
                {
                    Console.Write((arrBigger[i] + transfer) + " ");
                }
                else
                {
                    Console.Write(arrBigger[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}

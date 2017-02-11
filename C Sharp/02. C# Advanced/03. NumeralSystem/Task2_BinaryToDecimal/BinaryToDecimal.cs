using System;
using System.Linq;


namespace Task2_BinaryToDecimal
{
    class BinaryToDecimal
    {
        static void Main()
        {
            var binary = Console.ReadLine().ToArray();
            long decimalNumber = ConvertDecimalToBinary(binary);
            Console.WriteLine(decimalNumber);
        }

        static long ConvertDecimalToBinary(char[] arr)
        {
            long number = 0;
            for (long i = arr.Length - 1; i >= 0; i--)
            {
                number += (arr[i] - '0') * (long)Math.Pow(2, (arr.Length - i - 1));
            }
            return number;
        }
    }
}

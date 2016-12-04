using System;
using System.Numerics;

namespace Task10_NFactorial
{
    class NFactorial
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            FindFactorial(number);
        }

        static void FindFactorial(int number)
        {
            BigInteger factorial = 1;
            for (int i = number; i > 0; i--)
            {
                factorial *= i;
            }
            Console.WriteLine(factorial);
        }
    }
}

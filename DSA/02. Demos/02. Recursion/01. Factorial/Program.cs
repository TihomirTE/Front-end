using System;
using System.Numerics;

namespace _01.Factorial
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Factorial(50));
        }

        private static BigInteger Factorial(int n)
        {
            return Factorial(n, 1);
        }

        private static BigInteger Factorial(int n, BigInteger number)
        {
            if (n == 0)
            {
                return number;
            }

            return Factorial(n - 1, n * number);
        }
    }
}

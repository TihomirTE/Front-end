using System;
using System.Numerics;



namespace Calculate3
{
    class Program
    {
        static void Main()
        {
            double n = Convert.ToDouble(Console.ReadLine());
            double k = Convert.ToDouble(Console.ReadLine());

            var factorialN = new BigInteger();
            var factorialK = new BigInteger();
            var sum = new BigInteger();
            for (int i = 1, j = 1; i <= n; i++, j++)
            {
                factorialN *= i;
                if (j <= k)
                {
                    factorialK *= j;
                }
            }
            sum = factorialN / factorialK;
            Console.WriteLine(sum);
        }
    }
}

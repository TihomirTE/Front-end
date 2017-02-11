using System;


namespace Task5._1_Calculate
{
    class Program
    {
        static void Main()
        {
            double n = Convert.ToDouble(Console.ReadLine());
            double x = Convert.ToDouble(Console.ReadLine());
            double sum = 1 + 1 / x;
            double factorial = 1;
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
                sum += factorial / Math.Pow(x, (double)i);
            }
            Console.WriteLine("{0:f5}", sum);
        }
    }
}

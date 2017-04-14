using System;
using System.Diagnostics;

namespace _03.Advanced_Maths
{
    public class CompareAdvancedMaths
    {
        private const int NumberOfIterations = 10000000;

        public static void Main()
        {
            Console.WriteLine("Measure performance of - Square root");
            Console.WriteLine($"Float: {Timer<float>(a => (float)Math.Sqrt(a))}");
            Console.WriteLine($"Double: {Timer<double>(a => Math.Sqrt(a))}");
            Console.WriteLine($"Decimal: {Timer<decimal>(a => (decimal)Math.Sqrt((double)a))}");
            Console.WriteLine();

            Console.WriteLine("Measure performance of - Sinus");
            Console.WriteLine($"Float: {Timer<float>(a => (float)Math.Sin(a))}");
            Console.WriteLine($"Double: {Timer<double>(a => Math.Sin(a))}");
            Console.WriteLine($"Decimal: {Timer<decimal>(a => (decimal)Math.Sin((double)a))}");
            Console.WriteLine();

            Console.WriteLine("Measure performance of - Natural logarithm");
            Console.WriteLine($"Float: {Timer<float>(a => (float)Math.Log(a))}");
            Console.WriteLine($"Double: {Timer<double>(a => Math.Log(a))}");
            Console.WriteLine($"Decimal: {Timer<decimal>(a => (decimal)Math.Log((double)++a))}");
            Console.WriteLine();
        }

        /// <summary>
        /// Func<T1, Tr> represents a function, 
        /// that takes T1 argument and returns Tr.
        /// </summary>
        /// <param name="calculateFunc"></param>
        /// <returns> Calculate time for every value</returns>
        private static TimeSpan Timer<T>(Func<T, T> calculateFunc)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < NumberOfIterations; i++)
            {
                calculateFunc(default(T));
            }

            stopWatch.Stop();
            return stopWatch.Elapsed;
        }
    }
}

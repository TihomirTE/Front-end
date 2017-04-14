using System;
using System.Diagnostics;

namespace _02.Compare_simple_Maths
{
    public class SimpleMathsTests
    {
        private const int NumberOfIterations = 1000000;
        
        /// <summary>
        /// Timer<T>(Func<a, b, (a (arithmetic operation) b)>)
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Measure performance of - Add:");
            Console.WriteLine($"Int: {Timer<int>((a, b) => (a + b))}");
            Console.WriteLine($"Long: {Timer<long>((a, b) => (a + b))}");
            Console.WriteLine($"Float: {Timer<float>((a, b) => (a + b))}");
            Console.WriteLine($"Double: {Timer<double>((a, b) => (a + b))}");
            Console.WriteLine($"Decimal: {Timer<decimal>((a, b) => (a + b))}");
            Console.WriteLine();

            Console.WriteLine("Measure performance of - Substract:");
            Console.WriteLine($"Int: {Timer<int>((a, b) => (a - b))}");
            Console.WriteLine($"Long: {Timer<long>((a, b) => (a - b))}");
            Console.WriteLine($"Float: {Timer<float>((a, b) => (a - b))}");
            Console.WriteLine($"Double: {Timer<double>((a, b) => (a - b))}");
            Console.WriteLine($"Decimal: {Timer<decimal>((a, b) => (a - b))}");
            Console.WriteLine();

            Console.WriteLine("Measure performance of - Increment:");
            Console.WriteLine($"Int: {Timer<int>((a, b) => (a++))}");
            Console.WriteLine($"Long: {Timer<long>((a, b) => (a++))}");
            Console.WriteLine($"Float: {Timer<float>((a, b) => (a++))}");
            Console.WriteLine($"Double: {Timer<double>((a, b) => (a++))}");
            Console.WriteLine($"Decimal: {Timer<decimal>((a, b) => (a++))}");
            Console.WriteLine();

            Console.WriteLine("Measure performance of - Multiply:");
            Console.WriteLine($"Int: {Timer<int>((a, b) => (a * b))}");
            Console.WriteLine($"Long: {Timer<long>((a, b) => (a * b))}");
            Console.WriteLine($"Float: {Timer<float>((a, b) => (a * b))}");
            Console.WriteLine($"Double: {Timer<double>((a, b) => (a * b))}");
            Console.WriteLine($"Decimal: {Timer<decimal>((a, b) => (a * b))}");
            Console.WriteLine();

            // increment ++b because cannot divide to 0
            Console.WriteLine("Measure performance of - Divide:");
            Console.WriteLine($"Int: {Timer<int>((a, b) => (a / ++b))}");
            Console.WriteLine($"Long: {Timer<long>((a, b) => (a / ++b))}");
            Console.WriteLine($"Float: {Timer<float>((a, b) => (a / ++b))}");
            Console.WriteLine($"Double: {Timer<double>((a, b) => (a / ++b))}");
            Console.WriteLine($"Decimal: {Timer<decimal>((a, b) => (a / ++b))}");
            Console.WriteLine();
        }

        /// <summary>
        /// Func<T1, T2, ..., Tn, Tr> represents a function, 
        /// that takes (T1, T2, ..., Tn) arguments and returns Tr.
        /// </summary>
        /// <param name="calculateFunc"></param>
        /// <returns> Calculate time for every value</returns>
        private static TimeSpan Timer<T>(Func<T, T, T> calculateFunc)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < NumberOfIterations; i++)
            {
                calculateFunc(default(T), default(T));
            }

            stopWatch.Stop();
            return stopWatch.Elapsed;
        }
    }
}

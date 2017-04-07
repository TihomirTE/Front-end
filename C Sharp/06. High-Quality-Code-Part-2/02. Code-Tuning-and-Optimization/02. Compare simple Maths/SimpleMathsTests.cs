using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Compare_simple_Maths
{
    public class SimpleMathsTests
    {
        private const int NumberOfIterations = 1000000;

        //Func<T1, T2, ..., Tn, Tr> represents a function, 
        //that takes (T1, T2, ..., Tn) arguments and returns Tr.
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

        public static void Main()
        {
            Console.WriteLine("Add:");
            Console.WriteLine($"Int: {Timer<int>((a, b) => (a + b))}");
            Console.WriteLine($"Long: {Timer<long>((a, b) => (a + b))}");
            Console.WriteLine($"Float: {Timer<float>((a, b) => (a + b))}");
            Console.WriteLine($"Double: {Timer<double>((a, b) => (a + b))}");
            Console.WriteLine($"Decimal: {Timer<decimal>((a, b) => (a + b))}");
            Console.WriteLine();

            Console.WriteLine("Substract:");
            Console.WriteLine($"Int: {Timer<int>((a, b) => (a - b))}");
            Console.WriteLine($"Long: {Timer<long>((a, b) => (a - b))}");
            Console.WriteLine($"Float: {Timer<float>((a, b) => (a - b))}");
            Console.WriteLine($"Double: {Timer<double>((a, b) => (a - b))}");
            Console.WriteLine($"Decimal: {Timer<decimal>((a, b) => (a - b))}");
            Console.WriteLine();

            Console.WriteLine("Increment:");
            Console.WriteLine($"Int: {Timer<int>((a, b) => (a++))}");
            Console.WriteLine($"Long: {Timer<long>((a, b) => (a++))}");
            Console.WriteLine($"Float: {Timer<float>((a, b) => (a++))}");
            Console.WriteLine($"Double: {Timer<double>((a, b) => (a++))}");
            Console.WriteLine($"Decimal: {Timer<decimal>((a, b) => (a++))}");
            Console.WriteLine();

            Console.WriteLine("multiply:");
            Console.WriteLine($"Int: {Timer<int>((a, b) => (a * b))}");
            Console.WriteLine($"Long: {Timer<long>((a, b) => (a * b))}");
            Console.WriteLine($"Float: {Timer<float>((a, b) => (a * b))}");
            Console.WriteLine($"Double: {Timer<double>((a, b) => (a * b))}");
            Console.WriteLine($"Decimal: {Timer<decimal>((a, b) => (a * b))}");
            Console.WriteLine();

            // increment ++b cannot divide to 0
            Console.WriteLine("divide:");
            Console.WriteLine($"Int: {Timer<int>((a, b) => (a / ++b))}");
            Console.WriteLine($"Long: {Timer<long>((a, b) => (a / ++b))}");
            Console.WriteLine($"Float: {Timer<float>((a, b) => (a / ++b))}");
            Console.WriteLine($"Double: {Timer<double>((a, b) => (a / ++b))}");
            Console.WriteLine($"Decimal: {Timer<decimal>((a, b) => (a / ++b))}");
            Console.WriteLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task14_IntegerCalculations
{
    class IntegerCalculations
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
            decimal min = FindMinNumber(numbers);
            decimal max = FindMaxNumer(numbers);
            decimal sum = FindSum(numbers);
            decimal avg = sum / numbers.Length;
            decimal product = FindProduct(numbers);
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine("{0:f2}", avg);
            Console.WriteLine(sum);
            Console.WriteLine(product);
        }

        private static decimal FindProduct(decimal[] numbers)
        {
            decimal product = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                product *= numbers[i];
            }
            return product;
        }

        static decimal FindSum(decimal[] numbers)
        {
            decimal sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        static decimal FindMaxNumer(decimal[] numbers)
        {
            decimal max = decimal.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                    max = numbers[i];
            }
            return max;
        }

        static decimal FindMinNumber(decimal[] numbers)
        {
            decimal min = decimal.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                    min = numbers[i];
            }
            return min;
        }
    }
}

using System;
using System.Linq;

namespace _02.GoldFever
{
    public class Fever
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int sum = 0;
            int maxSum = 0;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] >= maxSum)
                {
                    maxSum = numbers[i];
                    continue;
                }

                sum += maxSum - numbers[i];
            }

            Console.WriteLine(sum);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_08
{
    public class Majorant
    {
        public static void Main()
        {
            var input = new List<int> { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            FindMajorant(input);
        }

        private static void FindMajorant(List<int> input)
        {
            var len = input.Count();

            var groupedNumbers = input
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .FirstOrDefault();

            if (groupedNumbers.Count() >= ((len / 2) + 1))
            {
                Console.WriteLine($"Majorant {groupedNumbers.Key} -> {groupedNumbers.Count()} occurrence");
            }
            else
            {
                Console.WriteLine("There is no majorant!");
            }
        }
    }
}

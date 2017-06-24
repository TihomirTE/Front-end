using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_07
{
    public class FindOccurrence
    {
        public static void Main()
        {
            var input = new List<int> { 3, 4, 4, 2, 3, 3, 4, 3, 2, 5, 0 };

            var findOccurrence = FindNumberOcuurrence(input);

            for (int i = 0; i < findOccurrence.Count; i++)
            {
                if (findOccurrence[i] > 0)
                {
                    Console.WriteLine($"{i} -> {findOccurrence[i]} times");
                }
            }
        }

        private static IList<int> FindNumberOcuurrence(IEnumerable<int> input)
        {
            var occurrence = new int[input.Max() + 1];

            foreach (var number in input)
            {
                occurrence[number]++;
            }

            return occurrence;
        }
    }
}

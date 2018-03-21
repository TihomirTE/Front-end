using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_06
{
    public class RemoveOddNumbers
    {
        public static void Main()
        {
            var input = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            var oddOccurrence = RemoveOddOccurrenceNumbers(input);

            Console.WriteLine(string.Join(", ", oddOccurrence));
        }

        private static IEnumerable<int> RemoveOddOccurrenceNumbers(IEnumerable<int> input)
        {
            var counters = new int[input.Max() + 1];

            foreach (var number in input)
            {
                counters[number]++;
            }

            var result = new List<int>();

            foreach (var number in input)
            {
                if (counters[number] % 2 == 0)
                {
                    result.Add(number);
                }
            }

            return result;
        }
    }
}

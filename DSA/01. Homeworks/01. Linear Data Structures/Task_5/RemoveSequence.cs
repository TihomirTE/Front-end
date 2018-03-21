using System;
using System.Collections.Generic;

namespace Task_05
{
    public class RemoveSequence
    {
        public static void Main()
        {
            var input = new List<int> { 1, 1, -4, 4, 4, -6, 6, 1, -5, -1 };

            var result = RemoveNegativeNumber(input);

            Console.WriteLine(string.Join(", ", result));
        }

        private static IEnumerable<int> RemoveNegativeNumber(IEnumerable<int> input)
        {
            var result = new List<int>();

            foreach (var number in input)
            {
                if (number > 0)
                {
                    result.Add(number);
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04
{
    public class Subsequence
    {
        public static void Main()
        {
            var input = new int[] { 1, 1, 4, 4, 4, 6, 6, 1, 5, 1 };

            var result = FindLongestSequenceOfEqualNumbers(input);

            Console.WriteLine(string.Join(", ", result));
        }

        private static IEnumerable<int> FindLongestSequenceOfEqualNumbers(IEnumerable<int> input)
        {
            var counters = new int[input.Max() + 1];

            foreach (var item in input)
            {
                counters[item]++;
            }

            var len = counters.Max();
            var element = Array.IndexOf(counters, len);

            var result = new List<int>();

            for (int i = 0; i < len; i++)
            {
                result.Add(element);
            }

            return result;
        }
    }
}

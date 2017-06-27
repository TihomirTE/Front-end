using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    public class CombinationsWithoutDuplicates
    {
        static void Main()
        {
            var n = 4;
            var k = 2;

            RecursionCombination(n, k);
        }

        private static void RecursionCombination(int maxNumber, int length, string result = "")
        {
            if (result.Length == length)
            {
                Console.WriteLine(result);
                return;
            }

            for (int i = 0; i < maxNumber; i++)
            {
                if (!result.Contains((i + 1).ToString()))
                {
                    RecursionCombination(maxNumber, length, result + (i + 1));
                }
            }
        }
    }
}

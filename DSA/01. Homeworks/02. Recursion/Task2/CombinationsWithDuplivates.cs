using System;

namespace Task_02
{
    public class CombinationsWithDuplicates
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
                RecursionCombination(maxNumber, length, result + (i + 1));
            }
        }
    }
}

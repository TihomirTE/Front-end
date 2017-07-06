using System;
using System.Linq;

namespace Task_06
{
    public class Subsets
    {
        private static string[] set;

        public static void Main()
        {
            set = new[] { "test", "rock", "fun" };
            int len = set.Length;
            int k = 2;

            int[] arr = new int[k];

            GenerateCombinations(arr);
        }

        private static void GenerateCombinations(int[] arr, int index = 0, int start = 0)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine("{0}", string.Join(", ", arr.Select(i => set[i])));
            }
            else
            {
                for (int i = start; i < set.Length; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(arr, index + 1, i + 1);
                }
            }
        }
    }
}

using System;
using System.Linq;
using Wintellect.PowerCollections;

namespace _05.Swapping
{
    public class Swapping
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var swapNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var len = swapNumbers.Length;

            var numbers = new BigList<int>();

            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (swapNumbers[i] == numbers[j])
                    {
                        int swapIndex = j;
                        int swapElement = numbers[j];
                        var subList = numbers.GetRange(swapIndex + 1, (n - swapIndex - 1));

                        numbers.RemoveRange(swapIndex, subList.Count + 1);
                        numbers.AddToFront(swapNumbers[i]);
                        numbers.AddRangeToFront(subList);

                        break;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

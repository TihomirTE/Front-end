using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Towns
{
    public class Towns
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var nums = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                var num = int.Parse(line[0]);
                nums.Add(num);
            }

            var result = Solve(nums);
            Console.WriteLine(result - 1);
        }

        private static int Solve(List<int> nums)
        {
            var len = nums.Count;
            var fromStartToEnd = Enumerable.Repeat(1, len).ToArray();

            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i] && fromStartToEnd[i] < fromStartToEnd[j] + 1)
                    {
                        fromStartToEnd[i] = fromStartToEnd[j] + 1;
                    }
                }
            }

            nums.Reverse();
            var fromEndToStart = Enumerable.Repeat(1, len).ToArray();
            var maxElement = 0;

            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i] && fromEndToStart[i] < fromEndToStart[j] + 1)
                    {
                        fromEndToStart[i] = fromEndToStart[j] + 1;
                    }
                }
            }

            var reversedArray = fromEndToStart.Reverse().ToArray();

            for (int i = 0; i < len; i++)
            {
                fromStartToEnd[i] = fromStartToEnd[i] + reversedArray[i];

                if (fromStartToEnd[i] > maxElement)
                {
                    maxElement = fromStartToEnd[i];
                }
            }

            return maxElement;
        }
    }
}

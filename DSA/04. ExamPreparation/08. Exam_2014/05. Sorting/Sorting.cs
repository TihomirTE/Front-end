using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Sorting
{
    public class Sorting
    {
        public static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var k = int.Parse(Console.ReadLine());

            var result = Solve(nums, k);
            Console.WriteLine(result);
        }

        private static int Solve(int[] nums, int k)
        {
            // Key - HashCode
            // Value - min path to Key
            var visited = new Dictionary<int, int>();

            var queue = new Queue<int[]>();
            queue.Enqueue(nums);

            visited.Add(GetHashCode(nums), 0);

            while (queue.Count > 0)
            {
                var currentPerm = queue.Dequeue();
                var currentPath = visited[GetHashCode(currentPerm)];
                if (IsSorted(currentPerm))
                {
                    // Get result
                    return currentPath;
                }

                for (int i = 0; i <= nums.Length - k; i++)
                {
                    var desc = currentPerm.Clone() as int[];
                    Array.Reverse(desc, i, k);

                    if (!visited.ContainsKey(GetHashCode(desc)))
                    {
                        visited.Add(GetHashCode(desc), currentPath + 1);
                        queue.Enqueue(desc);
                    }
                }
            }

            return -1;
        }

        private static bool IsSorted(int[] perm)
        {
            for (int i = 1; i < perm.Length; i++)
            {
                if (perm[i] < perm[i - 1])
                {
                    return false;
                }
            }

            return true;
        }
        
        private static int GetHashCode(int[] values)
        {
            int hashCode = 0;

            foreach (var val in values)
            {
                hashCode *= 10;
                hashCode += val;
            }

            return hashCode;
        }
    }
}

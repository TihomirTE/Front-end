using System;
using System.Linq;

namespace _02.OfficeSpace
{
    public class Program
    {
        private static int[] maxPathFrom;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var times = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var boolMatrix = new bool[n, n];

            for (int i = 0; i < n; i++)
            {
                var dependencies = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (dependencies.First() != 0)
                {
                    foreach (var dependecy in dependencies)
                    {
                        boolMatrix[dependecy - 1, i] = true;
                    }
                }
            }

            var resultTime = FindMinTime(n, times, boolMatrix);

            Console.WriteLine(resultTime);
        }

        private static int FindMinTime(int n, int[] times, bool[,] boolMatrix)
        {
            maxPathFrom = new int[n];
            var loopFound = false;

            var maxPath = 0;
            for (int i = 0; i < n; i++)
            {
                maxPath = Math.Max(DFS(i, times, boolMatrix, new bool[n], ref loopFound), maxPath);
                if (loopFound)
                {
                    return -1;
                }
            }

            return maxPath;
        }

        private static int DFS(int node, int[] times, bool[,] boolMatrix, bool[] visited, ref bool loopFound)
        {
            if (visited[node])
            {
                loopFound = true;
                return 0;
            }

            if (!visited[node] && maxPathFrom[node] > 0)
            {
                return maxPathFrom[node];
            }

            visited[node] = true;
            maxPathFrom[node] = times[node];
            for (int i = 0; i < times.Length; i++)
            {
                if (boolMatrix[i, node])
                {
                    maxPathFrom[node] = Math.Max(maxPathFrom[node],
                        DFS(i, times, boolMatrix, visited, ref loopFound) + times[node]);
                }
            }

            visited[node] = false;

            return maxPathFrom[node];
        }
    }
}

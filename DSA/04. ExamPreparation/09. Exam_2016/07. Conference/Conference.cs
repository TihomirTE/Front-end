using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Conference
{
    public class Conference
    {


        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var dev = input[0];
            var pairs = input[1];

            bool[] visited = new bool[dev];
            var graph = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < pairs; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var dev1 = line[0];
                var dev2 = line[1];

                if (!graph.ContainsKey(dev1))
                {
                    graph[dev1] = new HashSet<int>();
                }

                if (!graph.ContainsKey(dev2))
                {
                    graph[dev2] = new HashSet<int>();
                }

                graph[dev1].Add(dev2);
                graph[dev2].Add(dev1);
            }

            var nodesCount = new List<long>();

            foreach (var node in graph.Keys)
            {
                int componentCount = DFS(node, graph, visited);
                if (componentCount != 0)
                {
                    nodesCount.Add(componentCount);
                }
            }

            long counter = dev - graph.Keys.Count;

            long pairsCombination = 0;

            for (int i = 0; i < nodesCount.Count - 1; i++)
            {
                pairsCombination += nodesCount[i] * counter;
                for (int j = i + 1; j < nodesCount.Count; j++)
                {
                    pairsCombination += nodesCount[i] * nodesCount[j];
                }
            }

            if (counter > 0)
            {
                if (nodesCount.Count > 0)
                {
                    pairsCombination += nodesCount[nodesCount.Count - 1] * counter;
                }

                pairsCombination += (counter * (counter - 1)) / 2;
            }

            Console.WriteLine(pairsCombination);
        }

        private static int DFS(int node, Dictionary<int, HashSet<int>> graph, bool[] visited)
        {
            int result = 0;
            if (!visited[node])
            {
                visited[node] = true;
                result++;
                if (graph.ContainsKey(node))
                {
                    foreach (var child in graph[node])
                    {
                        if (!visited[child])
                        {
                            result += DFS(child, graph, visited);
                        }
                    }
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;

namespace _02.MaximalPath
{
    public class MaximalPath
    {
        private static int maxSum = 0;
        private static List<Node> usedNodes = new List<Node>();

        private static void DFS(Node node, int currentSum)
        {
            currentSum += node.Value;
            usedNodes.Add(node);

            for (int i = 0; i < node.NumberOfChildren; i++)
            {
                if (usedNodes.Contains(node.GetNode(i)))
                {
                    continue;
                }

                DFS(node.GetNode(i), currentSum);
            }

            if (node.NumberOfChildren == 1 && currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, Node> nodes = new Dictionary<int, Node>();

            for (int i = 0; i < n - 1; i++)
            {
                string connection = Console.ReadLine();
                string[] separated = connection.Split
                    (new char[] { '(', '<', '-', ')' }, StringSplitOptions.RemoveEmptyEntries);

                int parent = int.Parse(separated[0]);
                int child = int.Parse(separated[1]);

                Node parentNode;
                Node childNode;

                if (nodes.ContainsKey(parent))
                {
                    parentNode = nodes[parent];
                }
                else
                {
                    parentNode = new Node(parent);
                    nodes.Add(parent, parentNode);
                }

                if (nodes.ContainsKey(child))
                {
                    childNode = nodes[child];
                }
                else
                {
                    childNode = new Node(child);
                    nodes.Add(child, childNode);
                }

                parentNode.AddChild(childNode);
                childNode.AddChild(parentNode);
            }

            foreach (var node in nodes)
            {
                if (node.Value.NumberOfChildren == 1)
                {
                    usedNodes.Clear();
                    DFS(node.Value, 0);

                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._1_RecoverMessage_OriginalSolution
{
    class TopologicalSorting
    {
        static SortedDictionary<char, Node> graph = new SortedDictionary<char, Node>();

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            // set of all no incoming edges
            var edges = new SortedSet<char>();

            for (int i = 0; i < n; i++)
            {
                string lineMessage = Console.ReadLine();
                Node previousNode = GetNodeByCharFromGraph(lineMessage[0]);

                for (int j = 1; j < lineMessage.Length; j++)
                {
                    Node currentNode = GetNodeByCharFromGraph(lineMessage[j]);

                    previousNode.Successors.Add(currentNode);
                    currentNode.Parents.Add(previousNode);

                    previousNode = currentNode;
                }
            }

            // check for not incoming edges
            foreach (var node in graph.Values)
            {
                if (node.Parents.Count == 0)
                {
                    edges.Add(node.Value);
                }
            }

            // empty list that contain the sorted elements
            var result = new List<char>();

            while (edges.Count > 0)
            {
                // remove node
                var currentNodeSymbol = edges.Min;
                edges.Remove(currentNodeSymbol);

                // insert node in empty list
                result.Add(currentNodeSymbol);

                // check every children node if is no incoming
                var currentNode = graph[currentNodeSymbol];
                var children = currentNode.Successors.ToList();
                foreach (var child in children)
                {
                    child.Parents.Remove(currentNode);
                    currentNode.Successors.Remove(child);

                    if (child.Parents.Count == 0)
                    {
                        edges.Add(child.Value);
                    }
                }
            }

            Console.WriteLine(string.Join("", result));
        }

        static Node GetNodeByCharFromGraph(char symbol)
        {
            if (graph.ContainsKey(symbol))
            {
                return graph[symbol];
            }

            var newNode = new Node
            {
                Value = symbol
            };

            graph.Add(symbol, newNode);
            return newNode;
        }

        class Node
        {
            public Node()
            {
                this.Successors = new HashSet<Node>();
                this.Parents = new HashSet<Node>();
            }

            public char Value { get; set; }

            public ICollection<Node> Successors { get; set; }

            public ICollection<Node> Parents { get; set; }
        }
    }
}

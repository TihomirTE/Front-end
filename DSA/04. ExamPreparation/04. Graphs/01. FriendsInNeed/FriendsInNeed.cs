using System;
using System.Collections.Generic;

namespace _01.FriendsInNeed
{
    public class FriendsInNeed
    {
        public static void Main()
        {
            string[] numbers = Console.ReadLine().Split(' ');

            int numberOfPoints = int.Parse(numbers[0]);
            int numberOfStreets = int.Parse(numbers[1]);
            int numberOfHospital = int.Parse(numbers[2]);

            string[] allHospitals = Console.ReadLine().Split(' ');

            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();

            // Every Node has unique ID (because the key of graph is int - avoid duplication)
            Dictionary<int, Node> allNodes = new Dictionary<int, Node>();

            for (int i = 0; i < numberOfStreets; i++)
            {
                string[] currentStreet = Console.ReadLine().Split(' ');
                int startNode = int.Parse(currentStreet[0]);
                int endNode = int.Parse(currentStreet[1]);
                int distance = int.Parse(currentStreet[2]);

                if (!allNodes.ContainsKey(startNode))
                {
                    allNodes.Add(startNode, new Node(startNode));
                }

                if (!allNodes.ContainsKey(endNode))
                {
                    allNodes.Add(endNode, new Node(endNode));
                }

                Node startNodeObject = allNodes[startNode];
                Node endNodeObject = allNodes[endNode];

                if (!graph.ContainsKey(startNodeObject))
                {
                    // Create new Node with connections if the Node doesn't exist in the graph
                    graph.Add(startNodeObject, new List<Connection>());
                }

                if (!graph.ContainsKey(endNodeObject))
                {
                    // Create new Node with connections if the Node doesn't exist in the graph
                    graph.Add(endNodeObject, new List<Connection>());
                }

                // Add distance from the startNode to the endNode
                graph[startNodeObject].Add(new Connection(endNodeObject, distance));

                // Add distance from the endNode to the startNode (the streets are two-directions)
                graph[endNodeObject].Add(new Connection(startNodeObject, distance));
            }

            int result = int.MaxValue;

            // Set true on every Node which is Hospital
            for (int i = 0; i < allHospitals.Length; i++)
            {
                int currentHospital = int.Parse(allHospitals[i]);
                allNodes[currentHospital].IsHospital = true;
            }

            for (int i = 0; i < allHospitals.Length; i++)
            {
                int currentHospital = int.Parse(allHospitals[i]);

                DijkstraAlgorithm(graph, allNodes[currentHospital]);

                int currentSum = 0;

                foreach (var node in allNodes)
                {
                    if (!node.Value.IsHospital)
                    {
                        currentSum += node.Value.DijkstraDistance;
                    }
                }

                if (currentSum < result)
                {
                    result = currentSum;
                }
            }

            Console.WriteLine(result);

        }

        private static void DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, Node source)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = int.MaxValue;
            }

            source.DijkstraDistance = 0;
            // reorder queue with the new value
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                // reorder queue
                Node currentNode = queue.Dequeue();

                if (currentNode.DijkstraDistance == int.MaxValue)
                {
                    break;
                }

                foreach (var edge in graph[currentNode])
                {
                    var currentDistance = currentNode.DijkstraDistance + edge.Distance;

                    if (currentDistance < edge.ToNode.DijkstraDistance)
                    {
                        edge.ToNode.DijkstraDistance = currentDistance;

                        // reorder queue with the new value
                        queue.Enqueue(edge.ToNode);
                    }
                }
            }
        }
    }
}

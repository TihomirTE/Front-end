using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FriendsInNeed
{
    public class Program
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

            // Set true on every Node which is Hospital
            for (int i = 0; i < allHospitals.Length; i++)
            {
                int currentHospital = int.Parse(allHospitals[i]);
                allNodes[currentHospital].IsHospital = true;
            }

            Console.WriteLine();
        }

        public class Node : IComparable
        {
            public Node(int id)
            {
                this.ID = id;
                this.IsHospital = false;
            }

            public int ID { get; set; }

            // Save the smallest path (sum of distances) from one Node to another Node
            public int DijkstraDistance { get; set; }

            public bool IsHospital { get; set; }

            public int CompareTo(object obj)
            {
                if (!(obj is Node))
                {
                    return -1;
                }

                return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
            }
        }

        public class Connection // Edge
        {
            public Connection(Node node, int distance)
            {
                this.ToNode = node;
                this.Distance = distance;
            }

            public int Distance { get; set; }

            public Node ToNode { get; set; }
        }
    }
}

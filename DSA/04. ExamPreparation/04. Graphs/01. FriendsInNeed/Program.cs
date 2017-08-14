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

            int result = int.MaxValue;

            // Set true on every Node which is Hospital
            for (int i = 0; i < allHospitals.Length; i++)
            {
                int currentHospital = int.Parse(allHospitals[i]);
                allNodes[currentHospital].IsHospital = true;

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

    public class PriorityQueue<T> where T : IComparable
    {
        private T[] heap;
        private int index;

        public PriorityQueue()
        {
            this.heap = new T[16];
            this.index = 1;
        }

        public int Count
        {
            get
            {
                return this.index - 1;
            }
        }

        public void Enqueue(T element)
        {
            if (this.index >= this.heap.Length)
            {
                this.IncreaseArray();
            }

            this.heap[this.index] = element;

            int childIndex = this.index;
            int parentIndex = childIndex / 2;
            this.index++;

            while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
            {
                T swapValue = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[childIndex];
                this.heap[childIndex] = swapValue;

                childIndex = parentIndex;
                parentIndex = childIndex / 2;
            }
        }

        public T Dequeue()
        {
            T result = this.heap[1];

            this.heap[1] = this.heap[this.Count];
            this.index--;

            int rootIndex = 1;

            while (true)
            {
                int leftChildIndex = rootIndex * 2;
                int rightChildIndex = (rootIndex * 2) + 1;

                if (leftChildIndex > this.index)
                {
                    break;
                }

                int minChild;
                if (rightChildIndex > this.index)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        minChild = rightChildIndex;
                    }
                }

                if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                {
                    T swapValue = this.heap[rootIndex];
                    this.heap[rootIndex] = this.heap[minChild];
                    this.heap[minChild] = swapValue;

                    rootIndex = minChild;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public T Peek()
        {
            return this.heap[1];
        }

        private void IncreaseArray()
        {
            var copiedHeap = new T[this.heap.Length * 2];

            for (int i = 0; i < this.heap.Length; i++)
            {
                copiedHeap[i] = this.heap[i];
            }

            this.heap = copiedHeap;
        }
    }

}

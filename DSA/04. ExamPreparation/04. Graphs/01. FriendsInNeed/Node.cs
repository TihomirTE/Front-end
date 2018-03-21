using System;

namespace _01.FriendsInNeed
{
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
}

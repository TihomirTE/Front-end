namespace _01.FriendsInNeed
{
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

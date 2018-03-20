using System;

namespace Task2
{
    public class Program
    {
        public static void Main()
        {
            BinaryTree b = new BinaryTree();

            b.Insert(1);
            b.Insert(6);
            b.Insert(2);
            b.Insert(4);
            b.Insert(5);
            b.Insert(3);

            if(b.Search(int.Parse(Console.ReadLine())))
            {
                Console.WriteLine("Contains");
            }
            else
            {
                Console.WriteLine("Nope");
            }

            b.display();

            Console.ReadLine();
        }
    }

    public class BinaryTree
    {
        private Node root;
        private int count;

        public BinaryTree()
        {
            root = null;
            count = 0;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public void Insert(int d)
        {
            if (IsEmpty())
            {
                root = new Node(d);
            }
            else
            {
                root.InsertData(ref root, d);
            }

            count++;
        }

        public bool Search(int s)
        {
            return root.Search(root, s);
        }

        public bool IsLeaf()
        {
            if (!IsEmpty())
                return root.IsLeaf(ref root);

            return true;
        }

        public void display()
        {
            if (!IsEmpty())
                root.Display(root);
        }

        public int Count()
        {
            return count;
        }
    }

    public class Node
    {
        private int number;
        public Node rightLeaf;
        public Node leftLeaf;

        public Node(int value)
        {
            number = value;
            rightLeaf = null;
            leftLeaf = null;
        }

        public bool IsLeaf(ref Node node)
        {
            return (node.rightLeaf == null && node.leftLeaf == null);

        }

        public void InsertData(ref Node node, int data)
        {
            if (node == null)
            {
                node = new Node(data);

            }
            else if (node.number < data)
            {
                InsertData(ref node.rightLeaf, data);
            }

            else if (node.number > data)
            {
                InsertData(ref node.leftLeaf, data);
            }
        }

        public bool Search(Node node, int s)
        {
            if (node == null)
                return false;

            if (node.number == s)
            {
                return true;
            }
            else if (node.number < s)
            {
                return Search(node.rightLeaf, s);
            }
            else if (node.number > s)
            {
                return Search(node.leftLeaf, s);
            }

            return false;
        }

        public void Display(Node n)
        {
            if (n == null)
                return;

            Display(n.leftLeaf);
            Console.Write(" " + n.number);
            Display(n.rightLeaf);
        }

    }
}

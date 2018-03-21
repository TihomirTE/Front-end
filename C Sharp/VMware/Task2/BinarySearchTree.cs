using System;

namespace Task2
{
    /*
     Given a binary search tree you have to answer the question if a given number X belongs to the tree.
     A binary search tree is such a tree that each node has value (a positive integer) and two child nodes –
     left and right, following the rule that the value of the left node is not bigger than the value of the current node
     and also the value of the right not is strictly bigger than the value of the current node.
     Your task is to define Node and Tree elements and implement a function that by given Tree and element value answers
     if that value belongs to the tree.
     */
    public class Program
    {
        public static void Main()
        {
            BinaryTree binaryTree = new BinaryTree();

            binaryTree.Insert(5);
            binaryTree.Insert(1);
            binaryTree.Insert(6);
            binaryTree.Insert(2);
            binaryTree.Insert(4);
            binaryTree.Insert(8);
            binaryTree.Insert(7);
            binaryTree.Insert(3);

            Console.Write("Enter number ");
            int searchedNumber = int.Parse(Console.ReadLine());

            if (binaryTree.Search(searchedNumber))
            {
                Console.WriteLine($"{searchedNumber} contains in the binary tree");
            }
            else
            {
                Console.WriteLine($"{searchedNumber} DOES NOT contain in the binary tree");
            }

            binaryTree.DisplayTree();

            Console.ReadLine();
        }
    }

    public class BinaryTree
    {
        private Node root;
        private int count;

        public BinaryTree()
        {
            this.root = null;
            this.count = 0;
        }

        public bool IsEmpty()
        {
            return this.root == null;
        }

        public void Insert(int number)
        {
            if (IsEmpty())
            {
                this.root = new Node(number);
            }
            else
            {
                this.root.InsertData(ref this.root, number);
            }

            this.count++;
        }

        public bool Search(int number)
        {
            return this.root.Search(this.root, number);
        }

        public bool IsLeaf()
        {
            if (!IsEmpty())
            {
                return this.root.IsLeaf(ref this.root);
            }

            return true;
        }

        public void DisplayTree()
        {
            Console.Write("The given binary tree -> ");
            if (!IsEmpty())
            {
                this.root.DisplayNode(this.root);
            }
        }

        public int Count()
        {
            return this.count;
        }
    }

    public class Node
    {
        private int number;
        public Node rightLeaf;
        public Node leftLeaf;

        public Node(int value)
        {
            this.number = value;
            this.rightLeaf = null;
            this.leftLeaf = null;
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
            else if (node.number <= data)
            {
                this.InsertData(ref node.rightLeaf, data);
            }

            else if (node.number > data)
            {
                this.InsertData(ref node.leftLeaf, data);
            }
        }

        public bool Search(Node node, int number)
        {
            if (node == null)
                return false;

            if (node.number == number)
            {
                return true;
            }
            else if (node.number < number)
            {
                return Search(node.rightLeaf, number);
            }
            else if (node.number > number)
            {
                return Search(node.leftLeaf, number);
            }

            return false;
        }

        public void DisplayNode(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.DisplayNode(node.leftLeaf);
            Console.Write(node.number + " ");
            this.DisplayNode(node.rightLeaf);
        }
    }
}

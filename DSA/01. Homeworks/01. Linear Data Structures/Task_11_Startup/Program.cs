using System;
using LinkedList;

namespace Task_11_Startup
{
    public class Program
    {
        public static void Main()
        {
            var newList = new LinkedList<int>();

            newList.Add(1);
            newList.Add(2);
            newList.Add(3);
            newList.Add(4);
            newList.Add(5);

            newList.Remove(4);
            newList.RemoveAt(1);

            Console.WriteLine(newList.Contains(3));

            for (int i = 0; i < newList.Count; i++)
            {
                Console.WriteLine(newList[i]);
            }
        }
    }
}

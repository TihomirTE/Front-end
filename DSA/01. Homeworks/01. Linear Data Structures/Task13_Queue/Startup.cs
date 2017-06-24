using System;
using Task13_Queue.Queue;

namespace Task13_Queue
{
    public class Startup
    {
        public static void Main()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Console.WriteLine($"The Head is: {queue.Peek()}");

            while (queue.Count > 0)
            {
                Console.Write($"{queue.Dequeue()} ");
            }
            Console.WriteLine();
        }
    }
}

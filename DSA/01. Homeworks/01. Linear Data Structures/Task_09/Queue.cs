using System;
using System.Collections.Generic;

namespace Task_09
{
    public class Queue
    {
        public static void Main()
        {
            PrintSequence(2, 50);
        }

        private static void PrintSequence(int start, int sequenceLentgth)
        {
            var queue = new Queue<int>();

            queue.Enqueue(start);

            for (int i = 1; i < sequenceLentgth; i++)
            {
                var number = queue.Dequeue();
                Console.Write($"{number} ");

                queue.Enqueue(number + 1);
                queue.Enqueue((2 * number) + 1);
                queue.Enqueue(number + 2);
            }

            Console.WriteLine();
        }
    }
}

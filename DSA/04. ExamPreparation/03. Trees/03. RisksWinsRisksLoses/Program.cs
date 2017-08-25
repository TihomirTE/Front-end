using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RisksWinsRisksLoses
{
    public class Program
    {
        private static int result = 0;
        public static void Main()
        {
            var initialConfiguration = Console.ReadLine();
            var targetConfiguration = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            var visited = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                visited.Add(Console.ReadLine());
            }

            //FindTargetConfiguration(initialConfiguration, targetConfiguration);

            var queue = new Queue<string>();
            queue.Enqueue(initialConfiguration);
            visited.Add(initialConfiguration);

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current == targetConfiguration)
                {
                    Console.WriteLine(result);
                    return;
                }

                for (int i = 0; i < 5; i++)
                {
                    int digit = current[i] - '0';
                    digit++;
                    if (digit == 10)
                    {
                        digit = 0;
                    }
                }
            }

            Console.WriteLine(-1);

        }

        // Implement wiht Greedy algorithm -> 80 points in BGCoder
        private static void FindTargetConfiguration(string start, string end)
        {
            int counter = 0;
            int num = 1;
            int initialConfiguration = int.Parse(start);
            int targetConfiguration = int.Parse(end);

            for (int i = 1; i <= 5; i++)
            {
                int digitStart = (initialConfiguration / num) % 10;
                int digitTarget = (targetConfiguration / num) % 10;

                counter += Math.Min(Math.Abs(digitStart - digitTarget), 10 - (digitTarget - digitStart));

                num *= 10;
            }

            Console.WriteLine(counter);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_FirstLargerThanNeighbours
{
    class FirstLargerThanNeighbours
    {
        static int TakeFirstLarger(int[] example)
        {
            int biggest = int.MinValue;
            for (int i = 1; i < example.Length - 1; i++)
            {
                if (example[i] > example[i - 1] && example[i] > example[i + 1])
                {
                    return biggest = i;
                }
            }
            return -1;
        }

        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int index = TakeFirstLarger(arr);
            Console.WriteLine(index);
        }
    }
}

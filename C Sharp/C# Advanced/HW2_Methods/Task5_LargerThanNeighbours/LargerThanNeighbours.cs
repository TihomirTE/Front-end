using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_LargerThanNeighbours
{
    class LargerThanNeighbours
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            BiggerNeighbours(arr);
        }

        static void BiggerNeighbours(int[] arr)
        {
            int counter = 0;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                if (arr[i] < arr[i + 1] && arr[i + 1] > arr[i + 2])
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_AppearanceCount
{
    class AppearanceCount
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var arr = new int[number];
            arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int x = int.Parse(Console.ReadLine());
            int counter = CountNumber(arr, x);
            Console.WriteLine(counter);
        }

        static int CountNumber(int[] example, int num)
        {
            int counter = 0;
            for (int i = 0; i < example.Length; i++)
            {
                if (example[i] == num)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}

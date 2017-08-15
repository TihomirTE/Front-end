using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Trees
{
    public class Trees
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            long result = PlaceTree(a, b, c, d, -1);
            Console.WriteLine(result);
        }

        private static long PlaceTree(int a, int b, int c, int d, int lastType)
        {
            if (a == 0 && b == 0 && c == 0 && d == 0)
            {
                return 1;
            }

            long count = 0;

            if (a > 0 && lastType != 0)
            {
                count += PlaceTree(a - 1, b, c, d, 0);
            }

            if (b > 0 && lastType != 1)
            {
                count += PlaceTree(a, b - 1, c, d, 1);
            }

            if (c > 0 && lastType != 2)
            {
                 count += PlaceTree(a, b, c - 1, d, 2);
            }

            if (d > 0 && lastType != 3)

            {
                count += PlaceTree(a, b, c, d - 1, 3);
            }

            return count;
        }
    }
}

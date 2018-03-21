using System;

namespace _01.Trees
{
    public class Trees
    {
        // parameters for the different type of trees and lastType placed tree
        private static long[,,,,] memo = new long[11, 11, 11, 11, 5];

        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            long result = PlaceTree(a, b, c, d, 4);
            Console.WriteLine(result);
        }

        // Solved it with MEMOIZATION
        private static long PlaceTree(int a, int b, int c, int d, int lastType)
        {
            if (a == 0 && b == 0 && c == 0 && d == 0)
            {
                return 1;
            }

            // if we calculated previously - use it
            if (memo[a, b, c, d, lastType] > 0)
            {
                return memo[a, b, c, d, lastType];
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

            // Save new value when find it
            memo[a, b, c, d, lastType] = count;
            
            return count;
        }
    }
}

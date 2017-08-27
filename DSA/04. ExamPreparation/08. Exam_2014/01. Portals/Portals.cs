using System;
using System.Linq;

namespace _01.Portals
{
    public class Portals
    {
        private static string[,] matrix;
        private static int[,] passedPowers;
        private static int maxSumPower = int.MinValue;
        private static int sumPower = 0;

        public static void Main()
        {
            var startLocation = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int x = startLocation[0];
            int y = startLocation[1];

            var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int r = dimensions[0];
            int c = dimensions[1];

            matrix = new string[r, c];
            passedPowers = new int[r, c];

            for (int row = 0; row < r; row++)
            {
                var line = Console.ReadLine().Split(' ').ToArray();

                for (int col = 0; col < c; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            FindMaximalSum(x, y);

        }

        private static void FindMaximalSum(int row, int col)
        {
            if ((col < 0) || (row < 0) || (col >= matrix.GetLength(1)) || (row >= matrix.GetLength(0)))
            {
                return;
            }

            if (matrix[row, col] == "#")
            {
                return;
            }

            int power = int.Parse(matrix[row, col]);
            passedPowers[row, col] = power;

            if ((passedPowers[row, col] > matrix.GetLength(0)) || (passedPowers[row, col] > matrix.GetLength(1)))
            {
                return;
            }

            sumPower += power;
            matrix[row, col] = "#";

            FindMaximalSum(row, col - power); // left
            FindMaximalSum(row - power, col); // up
            FindMaximalSum(row, col + power); // right
            FindMaximalSum(row + power, col); // down

            if (sumPower > maxSumPower)
            {
                maxSumPower = sumPower;
            }

            sumPower = 0;

            matrix[row, col] = passedPowers[row, col].ToString();

            Console.WriteLine(maxSumPower);
            Environment.Exit(0);
        }
    }
}

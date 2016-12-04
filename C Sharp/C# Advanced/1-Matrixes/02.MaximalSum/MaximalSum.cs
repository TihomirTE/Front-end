using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_MaximalSum
{
    class MaximalSum
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var matrix = new int[numbers[0], numbers[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var colList = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
               
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colList[col];
                }
            }
            int bestSum = int.MinValue;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                    }
                }
            }
            Console.WriteLine(bestSum);
        }
    }
}

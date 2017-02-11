using System;
using System.Linq;
using System.Numerics;


namespace TaskWorkshop_BitShiftMatrix
{
    class Program
    {
        /* condition http://bgcoder.com/Contests/Practice/Index/223#2 */

        static int rows;
        static int cols;
        static int[] moves;
        static BigInteger[,] field;
        static void Main(string[] args)
        {
            // input
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());
            int movesCount = int.Parse(Console.ReadLine());
            moves = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            field = new BigInteger[rows, cols];
            FillMatrix();

            BigInteger sum = 0;
            int[] pos = { rows - 1, 0 };  // starting point
            sum += field[pos[0], pos[1]];
            field[pos[0], pos[1]] = 0;
            int coeff = rows > cols ? rows : cols;
            foreach (var code in moves)
            {
                int[] targetPos = { code / coeff, code % coeff };

                int stepRow = pos[0] == targetPos[0] ? 0 : (pos[0] < targetPos[0] ? 1 : -1);
                int stepCol = pos[1] == targetPos[1] ? 0 : (pos[1] < targetPos[1] ? 1 : -1);
                do
                {
                    // moving on columns
                    pos[1] += stepCol;
                    sum += field[pos[0], pos[1]];
                    field[pos[0], pos[1]] = 0; // visited cell
                } while (pos[1] != targetPos[1] && pos[1] >= 0 && pos[1] < cols);

                do
                {
                    // moving on rows
                    pos[0] += stepRow;
                    sum += field[pos[0], pos[1]];
                    field[pos[0], pos[1]] = 0; // visited cell
                } while (pos[0] != targetPos[0] && pos[0] >= 0 && pos[0] < rows);
            }
            Console.WriteLine(sum);
        }

        private static void FillMatrix()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    field[r, c] = (BigInteger)1 << (rows - 1 - r + c);
                }
            }
        }
    }
}

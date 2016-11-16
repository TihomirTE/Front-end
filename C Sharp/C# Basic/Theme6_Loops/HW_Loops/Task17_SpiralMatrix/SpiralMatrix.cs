using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task17_SpiralMatrix
{
    class SpiralMatrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int row = 0;
            int col = 0;
            int counter = 0;
            int i = 1;
            while (i <= (n * n))
            {
                for (int colsRight = 0 + counter; colsRight < n - counter; colsRight++)
                {
                    matrix[row, colsRight] = i++;
                    col = colsRight;
                    if (i == (n * n) + 1)
                        goto Here;
                }

                for (int rowsDown = 1 +counter; rowsDown < n - counter; rowsDown++)
                {
                    matrix[rowsDown, col] = i++;
                    row = rowsDown;
                    if (i == (n * n) + 1)
                        goto Here;
                }
                for (int colsLeft = n - 2 - counter; colsLeft >= 0 + counter; colsLeft--)
                {
                    matrix[row, colsLeft] = i++;
                    col = colsLeft;
                    if (i == (n * n) + 1)
                        goto Here;
                }
                for (int rowsUp = n - 2 - counter; rowsUp > 0 + counter; rowsUp--)
                {
                    matrix[rowsUp, col] = i++;
                    row = rowsUp;
                    if (i == (n * n) + 1)
                        goto Here;
                }
                counter++;
            }
            Here:
            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < n; cols++)
                {
                    Console.Write("{0} ", matrix[rows, cols]);
                }
                Console.WriteLine();
            }
        }
    }
}


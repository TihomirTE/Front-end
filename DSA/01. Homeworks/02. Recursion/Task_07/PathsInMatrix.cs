using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task_07
{
    class Program
    {
        // passable cells -> ' '
        // not passable -> 'x'
         
        static char[,] matrix =
        {
            {' ', ' ', ' ', 'x', ' ', ' ', ' '},
            {'x', 'x', ' ', 'x', ' ', 'x', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', 'x', 'x', 'x', 'x', 'x', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'е'},
        };

        static void Main()
        {
            FindExit(0, 0);
        }

        private static void FindExit(int row, int col)
        {
            if ((col < 0) || (row < 0) || (row >= matrix.GetLength(0)) || (col >= matrix.GetLength(1)))
            {
                // out of the matrix
                return;
            }

            if (matrix[row, col] == 'e')
            {
                Console.WriteLine("Exit");
            }

            if (matrix[row, col] != ' ')
            {
                // the cell is not free
                return;
            }

            // temporary mark the cell as visited
            matrix[row, col] = 's';

            FindExit(row, col - 1);
            FindExit(row - 1, col);
            FindExit(row, col + 1);
            FindExit(row + 1, col);

            // free the cell
            matrix[row, col] = ' ';
        }
    }
}

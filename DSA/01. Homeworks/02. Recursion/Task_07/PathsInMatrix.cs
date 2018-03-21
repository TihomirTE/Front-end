using System;
using System.Collections.Generic;

namespace Task_07
{
    // TODO Print all paths

    public class PathsInMatrix
    {
        // passable cells -> ' '
        // not passable -> 'x'
         
        public static char[,] matrix =
        {
            {' ', ' ', ' ', 'x', ' ', ' ', ' '},
            {'x', 'x', ' ', 'x', ' ', 'x', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', 'x', 'x', 'x', 'x', 'x', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'е'},
        };

        public static List<char> path = new List<char>();

        public static void Main()
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

            FindExit(row, col - 1); // left
            FindExit(row - 1, col); // up
            FindExit(row, col + 1); // right
            FindExit(row + 1, col); // down

            // free the cell
            matrix[row, col] = ' ';
        }
    }
}

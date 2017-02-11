using System;
using System.Linq;


namespace Task3_SequenceInMatrix
{
    class SequenceInMatrix
    {
        static void Main(string[] args)
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
            int bestSequence = 0;

            // Check for equal column
            int currentCol = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                        if (matrix[row, col] == matrix[row + 1, col])
                    {
                        currentCol++;
                        if (currentCol > bestSequence)
                            bestSequence = currentCol;
                    }
                   
                    else
                        currentCol = 1;
                }
            }
            // Check for equal row
            int currentRow = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1])
                    {
                        currentRow++;
                        if (currentRow > bestSequence)
                            bestSequence = currentRow;
                    }
                    else
                        currentRow = 1;
                }
            }
            // Check for equal diagonal
            int currentDiagonal = 1;
            for (int rows = 0, cols = 0; cols < matrix.GetLength(1) - 1; rows++, cols++)
            {
                int row = rows;
                int col = cols;
                while (matrix[row, col] == matrix[row + 1, col + 1]
                    && col < matrix.GetLength(1) - 1)
                {
                    currentDiagonal++;
                    if (currentDiagonal > bestSequence)
                        bestSequence = currentDiagonal;
                    row = row + 1;
                    col = col + 1;
                }
                row = rows;
                col = cols;
                while (col > 0 && matrix[row, col] == matrix[row + 1, col - 1])
                {
                    currentDiagonal++;
                    if (currentDiagonal > bestSequence)
                        bestSequence = currentDiagonal;
                    row = row + 1;
                    col = col - 1;
                }
            }
            for (int cols = 1, rows = matrix.GetLength(0) - 1; cols < matrix.GetLength(1) - 1; cols++, rows++)
            {
                int row = rows;
                int col = cols;
                while ((col < matrix.GetLength(1) - 1) && matrix[row, col] == matrix[row - 1, col + 1])
                {
                    currentDiagonal++;
                    if (currentDiagonal > bestSequence)
                        bestSequence = currentDiagonal;
                    row = row - 1;
                    col = col + 1;
                }

                row = rows;
                col = cols;
                while (col > 0 && matrix[row, col] == matrix[row - 1, col - 1])
                {
                    currentDiagonal++;
                    if (currentDiagonal > bestSequence)
                        bestSequence = currentDiagonal;
                    row = row - 1;
                    col = col - 1;
                }
            }
            Console.WriteLine(bestSequence);
        }
    }
}

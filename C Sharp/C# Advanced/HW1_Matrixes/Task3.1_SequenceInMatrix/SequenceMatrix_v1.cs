using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1_SequenceInMatrix
{
    class SequenceMatrix_v1
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
            int bestSequence = 0;
            int currentSequence = 1;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    int row = rows;
                    int col = cols;
                        while ((col < matrix.GetLength(1) - 1) && matrix[row, col] == matrix[row, col + 1])
                        {
                            col++;
                            currentSequence++;
                        }
                        if (currentSequence > bestSequence)
                        {
                            bestSequence = currentSequence;
                        }
                    currentSequence = 1;
                    row = rows;
                    col = cols;
                        while ((col < matrix.GetLength(1) - 1) && (row < matrix.GetLength(0) - 1) 
                        && matrix[row, col] == matrix[row + 1, col + 1])
                        {
                            row++;
                            col++;
                            currentSequence++;
                        }
                        if (currentSequence > bestSequence)
                        {
                            bestSequence = currentSequence;
                        }
                    currentSequence = 1;
                    row = rows;
                    col = cols;
                        while ((row < matrix.GetLength(0) - 1) && matrix[row, col] == matrix[row + 1, col])
                        {
                            row++;
                            currentSequence++;
                        }
                        if (currentSequence > bestSequence)
                        {
                            bestSequence = currentSequence;
                        }
                    currentSequence = 1;
                    row = rows;
                    col = cols;
                        while (col > 0 && (row < matrix.GetLength(0) - 1) 
                        && matrix[row, col] == matrix[row + 1, col - 1])
                        {
                            row++;
                            col--;
                            currentSequence++;
                        }
                    if (currentSequence > bestSequence)
                    {
                        bestSequence = currentSequence;
                    }
                    currentSequence = 1;
                }
            }
            Console.WriteLine(bestSequence);
        }
    }
}

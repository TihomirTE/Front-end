using System;

namespace _01.Sudoku
{
    public class Sudoku
    {
        private static int[,] sudokuField = new int[9, 9];

        public static void Main()
        {
            for (int i = 0; i < 9; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < 9; j++)
                {
                    if (line[j] == '-')
                    {
                        sudokuField[i, j] = 0;
                    }
                    else
                    {
                        sudokuField[i, j] = line[j] - '0';
                    }
                }
            }

            // for faster solution -> it's not HQC
            //try
            //{
            FillSudokuField(0, 0);
            //}
            //catch
            //{
            //}

        }

        private static void FillSudokuField(int row, int col)
        {
            if (row == 9 && col == 0)
            {
                PrintSudoku();
                return;

                // for faster solution -> it's not HQC
                //throw new Exception();
            }
            else if (sudokuField[row, col] == 0)
            {
                for (int i = 1; i <= 9; i++)
                {
                    if (CheckRow(row, i) || CheckCol(col, i) || CheckSquare(row, col, i))
                    {
                        continue;
                    }

                    sudokuField[row, col] = i;
                    FillSudokuField(NextRow(row, col), NextCol(col));
                    sudokuField[row, col] = 0;
                }
            }
            else
            {
                FillSudokuField(NextRow(row, col), NextCol(col));

            }
        }

        private static int NextRow(int row, int col)
        {
            col++;
            if (col > 8)
            {
                return row + 1;
            }

            return row;
        }

        private static int NextCol(int col)
        {
            col++;
            if (col > 8)
            {
                return 0;
            }

            return col;
        }

        private static bool CheckRow(int row, int number)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudokuField[row, i] == number)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckCol(int col, int number)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudokuField[i, col] == number)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckSquare(int row, int col, int number)
        {
            // start from the first row of the current small square
            int startRow = (row / 3) * 3;

            // start from the first column of the current small square
            int startCol = (col / 3) * 3;

            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    if (sudokuField[i, j] == number)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void PrintSudoku()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(sudokuField[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_FillTheMatrix
{
    class FillTheMatrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var letter = Console.ReadLine();
            var matrix = new int[n, n];
            int number = 1;
            int counter = 0;

            if (letter == "a")
            {
                for (int col = 0; col < n; col++)
                {
                    for (int row = 0; row < n; row++)
                    {
                        matrix[row, col] = number;
                        number++;
                    }
                }

            }
            else if (letter == "b")
            {

                for (int col = 0; col < n; col++)
                {
                    if (col % 2 == 0)
                        for (int row = 0; row < n; row++)
                        {
                            matrix[row, col] = number;
                            number++;
                        }
                    else
                        for (int row = n - 1; row >= 0; row--)
                        {
                            matrix[row, col] = number;
                            number++;
                        }
                }
            }
            else if (letter == "c")
            {
                int row = n - 1;
                int col = 0;
                while (number <= n * n)
                {
                    matrix[row, col] = number;
                    if (row == n - 1 && col == n - 1)
                    {
                        row = 0;
                        col = 1;
                    }
                    else if (row == n - 1)
                    {
                        row = row - col - 1;
                        col = 0;
                    }
                    else if (col == n - 1)
                    {
                        col = col - row + 1;
                        row = 0;
                    }
                    else
                    {
                        row++;
                        col++;
                    }
                    number++;
                }
            }

            else if (letter == "d")
            {
                while (number <= n * n)
                {
                    for (int rowDown = counter, col = counter; rowDown < n - counter; rowDown++)
                    {
                        matrix[rowDown, col] = number;
                        number++;
                    }
                    for (int colRight = 1 + counter, row = (n - 1) - counter; colRight < n - counter; colRight++)
                    {
                        matrix[row, colRight] = number;
                        number++;
                    }
                    for (int rowUp = (n - 2) - counter, col = (n - 1) - counter; rowUp >= counter - 0; rowUp--)
                    {
                        matrix[rowUp, col] = number;
                        number++;
                    }
                    for (int colLeft = (n - 2) - counter, row = counter - 0; colLeft >= counter + 1; colLeft--)
                    {
                        matrix[row, colLeft] = number;
                        number++;
                    }
                    counter++;
                }
            }
            // Print the matrix
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (col == n - 1)
                        Console.Write("{0}", matrix[row, col]);
                    else
                        Console.Write("{0} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}


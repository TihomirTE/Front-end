using System;
using System.Linq;

namespace _06.Guards
{
    public class Guards
    {
        public static void Main()
        {
            var dimenssions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rows = dimenssions[0];
            var cols = dimenssions[1];

            var lab = new long[rows, cols];

            var numberOfGuards = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfGuards; i++)
            {
                var line = Console.ReadLine().Split(' ').ToArray();
                var r = int.Parse(line[0]);
                var c = int.Parse(line[1]);
                var dir = line[2];

                lab[r, c] = 1000000;

                if (c > 0 && dir == "L" && lab[r, c - 1] == 0)
                {
                    lab[r, c - 1] = 3;
                }
                else if ((c < cols - 1) && dir == "R" && lab[r, c + 1] == 0)
                {
                    lab[r, c + 1] = 3;
                }
                else if (r > 0 && dir == "U" && lab[r - 1, c] == 0)
                {
                    lab[r - 1, c] = 3;
                }
                else if ((r < rows - 1) && dir == "D" && lab[r + 1, c] == 0)
                {
                    lab[r + 1, c] = 3;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (lab[row, col] == 0)
                    {
                        lab[row, col] = 1;
                    }

                    if (row == 0 && col == 0)
                    {
                        continue;
                    }

                    if (row == 0)
                    {
                        lab[row, col] += lab[row, col - 1];
                    }
                    else if (col == 0)
                    {
                        lab[row, col] += lab[row - 1, col];
                    }
                    else
                    {
                        lab[row, col] += Math.Min(lab[row, col - 1], lab[row - 1, col]);
                    }
                }
            }

            var result = lab[rows - 1, cols - 1];

            if (result < 1000000)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Meow");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_BitShiftMatrix
{
    class BitShiftMatrix
    {
        static void Main()
        {
            // input
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int numberMoves = int.Parse(Console.ReadLine());
            var codes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int coeff = Math.Max(rows, cols);
            MoveThePawn(codes, coeff, numberMoves, rows, cols);

        }

        private static void MoveThePawn(int[] codes, int coeff, int moves, int rows, int cols)
        {
            int x = rows - 1;
            int y = 0;
            int number = 1;
            bool visited = false;
            var matrix = new int[rows, cols];
            for (int i = 0; i < moves; i++)
            {
                int x1 = codes[i] / coeff;
                int y1 = codes[i] % coeff;
                int diffY = y1 - y;
               
                if (diffY >= 0)
                {
                    number = CalculateTheMove(diffY, number);
                }
                else
                {
                    number -= number >> diffY;
                }
                int diffX = x1 - x;
                if (diffX >= 0)
                {
                    number += number << diffX;
                }
                else
                {
                    number -= number >> diffX;
                }
            }
        }

        private static int CalculateTheMove(int diff, int num)
        {
            for (int i = 1; i <= diff; i++)
            {
                num += num << 1;
            }
            return num;
        }
    }
}

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
            
            int sum = 0;
            for (int i = 0; i < numberMoves; i++)
            {
                sum += CalculateTheMove(codes[i], coeff);
            }
        }

        static int CalculateTheMove(int move, int coeff)
        {
            int row = move / coeff;
            int col = move % coeff;

            int currentSum = SumTheMovement(row, col);
            return currentSum;
        }

        static int SumTheMovement(int row, int col)
        {
            
        }
    }
}

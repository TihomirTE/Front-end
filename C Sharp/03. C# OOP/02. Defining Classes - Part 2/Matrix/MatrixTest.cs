using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class MatrixTest
    {
        // This class is for testing on Matrix.
        // First comment others Main methods!!!

        static void Main()
        {
            Matrix<int> firstMatrix = new Matrix<int>(5, 2);
            Matrix<int> secondMatrix = new Matrix<int>(2, 4);

            // fill the first matrix
            for (int row = 0; row < firstMatrix.Rows; row++)
            {
                for (int col = 0; col < secondMatrix.Cols; col++)
                {
                    firstMatrix[row, col] = row + col + 1;
                }
            }

            // fill the second matrix
            for (int row = 0; row < secondMatrix.Rows; row++)
            {
                for (int col = 0; col < secondMatrix.Cols; col++)
                {
                    secondMatrix[row, col] = row * col;
                }
            }

            //addition 
            //Matrix<int> result = firstMatrix + secondMatrix;

            //substraction
            //Matrix<int> result = firstMatrix - secondMatrix;

            //multiplication
            Matrix <int> result = firstMatrix * secondMatrix;

            if (firstMatrix)
            {
                Console.WriteLine("Does not have zero element");
            }
            else
            {
                Console.WriteLine("Has zero element");
            }
            Console.WriteLine();
        }
    }
}

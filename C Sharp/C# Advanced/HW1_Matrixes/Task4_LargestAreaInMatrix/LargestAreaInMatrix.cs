using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_LargestAreaInMatrix
{
    class LargestAreaInMatrix
    {
        private static bool[,] visited;
        private static int[,] matrix;
        private static int biggestSequenceOfEqualElements = 0;
        private static int currentEqualElement = 0;
        private static int rows; 
        private static int cols; 

        static void Main()
        {

            // Read the matrix size (rows and cols)
            var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            rows = sizes[0];
            cols = sizes[1];

            // Allocate the matrix
            matrix = new int[rows, cols];

            // Enter the matrix elements
            for (int row = 0; row < rows; row++)  
            {
                var inputRows = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++) 
                {
                    matrix[row, col] = inputRows[col];
                }
            }

            // the bool matrix (for visited element)
            visited = new bool[rows, cols];

            // Find the largest area of equal neighbour elements
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    FindTheLargestArea(i, j, matrix[i, j]);

                    if (biggestSequenceOfEqualElements < currentEqualElement)
                    {
                        biggestSequenceOfEqualElements = currentEqualElement;
                    }
                    currentEqualElement = 0;
                }
            }

            // Result
            Console.WriteLine(biggestSequenceOfEqualElements);
        }

        private static void FindTheLargestArea(int row, int col, int currentElement)
        {
            //returns if we are out of the matrix or the element is not the same
            if ((row < 0) || (row >= rows)
                || (col < 0) || (col >= cols)
                || currentElement != matrix[row, col])
            {
                return;
            }

            // To skip visited element (not to recall the recursion)
            if (visited[row, col])
            {
                return;
            }

            // Mark the current cell as visited
            visited[row, col] = true;

            currentEqualElement++;

            // Invoke recursion to explore all possible directions
            FindTheLargestArea((row - 1), col, currentElement); // up
            FindTheLargestArea((row + 1), col, currentElement); // down    
            FindTheLargestArea(row, (col - 1), currentElement); // left        
            FindTheLargestArea(row, (col + 1), currentElement); // right    
        }
    }
 }

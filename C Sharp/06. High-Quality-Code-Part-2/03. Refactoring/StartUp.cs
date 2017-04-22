using System;

namespace RotatingWalkInMatrix
{
    public class RotatingWalkInMatrix
    {
        public static void Main()
        {
            string input;

            Console.WriteLine("Enter number between 1 and 100");
            input = Console.ReadLine();

            Matrix matrix = new Matrix(input);
            Console.WriteLine(matrix);
        }
    }
}
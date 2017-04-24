using System;

namespace RotatingWalkInMatrix
{
    public class StartUp
    {
        public static void Main()
        {
            string input;

            Console.WriteLine("Enter number between 1 and 100");
            input = Console.ReadLine();

            WalkInMatrix matrix = new WalkInMatrix(input);
            Console.WriteLine(matrix);
        }
    }
}
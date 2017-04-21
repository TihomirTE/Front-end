namespace RotatingWalkInMatrix
{
    using System;

    public class RotatingWalkInMatrix
    {
        public static void Main()
        {
            int input;

            do
            {
                Console.WriteLine("Enter number between 1 and 100");
                input = int.Parse(Console.ReadLine());
            } while (input <= 0 || input > 100);

            Matrix matrix = new Matrix(input);
            Console.WriteLine(matrix);
        }
    }
}
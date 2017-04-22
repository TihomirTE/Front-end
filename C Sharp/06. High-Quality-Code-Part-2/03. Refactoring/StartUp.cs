namespace RotatingWalkInMatrix
{
    using System;

    public class RotatingWalkInMatrix
    {
        public static void Main()
        {
            int input;
            
                Console.WriteLine("Enter number between 1 and 100");
                input = int.Parse(Console.ReadLine());
           

            Matrix matrix = new Matrix(input);
            Console.WriteLine(matrix);
        }
    }
}
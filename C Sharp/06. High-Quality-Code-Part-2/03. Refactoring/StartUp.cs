using System;
using GameFifteen.Models;

namespace GameFifteen
{
    public class StartUp
    {
        static void Main()
        {
            int input;

            do
            {
                Console.WriteLine("Enter number between 1 and 100");
                input = int.Parse(Console.ReadLine());
            } while (input < 1 || input > 100);

            Matrix matrix = new Matrix(input);
            Console.WriteLine(matrix);
        }
    }
}

           

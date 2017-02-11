using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_GetLargestNumber
{
    class GetLargestNumber
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ');
            int number1 = int.Parse(numbers[0]);
            int number2 = int.Parse(numbers[1]);
            int number3 = int.Parse(numbers[2]);
            int bigger = GetMax(number1, number2);
            int biggest = GetMax(number3, bigger);
            Console.WriteLine(biggest);
        }

        static int GetMax(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task15_GCD
{
    class GCD
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int num1 = Math.Max(numbers[0], numbers[1]);
            int num2 = Math.Min(numbers[0], numbers[1]);
            int currentNum = 0;

            int remainder = num1 % num2;
            if (remainder == 0)
            {
                Console.WriteLine(num2);
            }
            else
            {
                while (num2 != 0)
                {
                    currentNum = num1;
                    num1 = num2;
                    num2 = currentNum % num1;

                }
                Console.WriteLine(num1);
            }
         }
    }
}

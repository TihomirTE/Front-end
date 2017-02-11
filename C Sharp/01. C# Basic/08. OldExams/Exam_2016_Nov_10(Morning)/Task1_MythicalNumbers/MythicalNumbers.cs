using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_MythicalNumbers
{
    class MythicalNumbers
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            double thirdDigit = number % 10;
            double secondDigit = (number / 10) % 10;
            double firstDigit = (number / 100) % 10;
            double result = 0;

            if (thirdDigit == 0)
            {
                result = secondDigit * firstDigit;
            }
            else if (thirdDigit > 0 && thirdDigit <= 5)
            {
                result = (firstDigit * secondDigit) / thirdDigit;
            }
            else
            {
                result = (firstDigit + secondDigit) * thirdDigit;
            }
            Console.WriteLine("{0:f2}", result);
        }
    }
}

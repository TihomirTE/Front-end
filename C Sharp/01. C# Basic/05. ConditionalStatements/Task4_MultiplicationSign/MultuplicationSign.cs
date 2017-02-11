using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_MultiplicationSign
{
    class MultuplicationSign
    {
        static void Main()
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());

            if ((num1 > 0 && num2 > 0 && num3 > 0) || (num1 > 0 && num2 < 0 && num3 < 0)
                || (num1 < 0 && num2 < 0 && num3 > 0) || (num1 < 0 && num2 > 0 && num3 < 0))
            {
                Console.WriteLine("+");
            }
            else if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine("-");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_BiggestOf3
{
    class BiggestOf3
    {
        static void Main()
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());

            double max = 0;
            max = Math.Max(num1, num2);
            if (num3 > max)
            {
                max = num3;
            }
            Console.WriteLine(max);
        }
    }
}

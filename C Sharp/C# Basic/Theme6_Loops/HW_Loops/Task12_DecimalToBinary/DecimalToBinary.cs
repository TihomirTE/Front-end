using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_DecimalToBinary
{
    class DecimalToBinary
    {
        static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            StringBuilder binary = new StringBuilder();
            long digit = 0;

            while (number > 0)
            {
                digit = number % 2;
                binary.Insert(0, digit);
                number /= 2;
            }
            Console.WriteLine(binary);
        }
    }
}

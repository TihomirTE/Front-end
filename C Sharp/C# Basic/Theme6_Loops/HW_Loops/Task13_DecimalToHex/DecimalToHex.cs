using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13_DecimalToHex
{
    class DecimalToHex
    {
        static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            StringBuilder hex = new StringBuilder();
            long digit = 0;

            while (number > 0)
            {
                digit = number % 16;
                if (digit >=0 && digit <= 9)
                {
                    hex.Insert(0, digit);
                }
                else
                {
                    switch (digit)
                    {
                        case 10: hex.Insert(0, "A"); break;
                        case 11: hex.Insert(0, "B"); break;
                        case 12: hex.Insert(0, "C"); break;
                        case 13: hex.Insert(0, "D"); break;
                        case 14: hex.Insert(0, "E"); break;
                        case 15: hex.Insert(0, "F"); break;
                        default: break;
                    }
                }
                number /= 16;
            }
            Console.WriteLine(hex);
        }
    }
}

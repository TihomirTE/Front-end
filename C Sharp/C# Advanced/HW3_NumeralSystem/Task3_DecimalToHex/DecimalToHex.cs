using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_DecimalToHex
{
    class DecimalToHex
    {
        static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            string hexNumber = ConvertDecimalToHex(number);
            Console.WriteLine(hexNumber);
        }

        static string ConvertDecimalToHex(long number)
        {
            string hexNumber = string.Empty;
            while (number > 0)
            {
                int remainder = (int)(number % 16);
                if (remainder < 10)
                {
                    hexNumber = remainder + hexNumber;
                }
                else
                {
                    switch (remainder)
                    {
                        case 10: hexNumber = "A" + hexNumber;break;
                        case 11: hexNumber = "B" + hexNumber; break;
                        case 12: hexNumber = "C" + hexNumber; break;
                        case 13: hexNumber = "D" + hexNumber; break;
                        case 14: hexNumber = "E" + hexNumber; break;
                        case 15: hexNumber = "F" + hexNumber; break;
                        default: break;
                    }
                }
                number /= 16;
            }
            return hexNumber;
        }
    }
}

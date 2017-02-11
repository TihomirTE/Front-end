using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_DecimalToBynary
{
    class Program
    {
        static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            string binary = ConvertDecimalTobinary(number);
            Console.WriteLine(binary);
        }

        static string ConvertDecimalTobinary(long number)
        {
            string binary = "";
            int digit = 0;
            while (number > 0)
            {
                digit = (int)(number & 1);
                binary = digit + binary;
                number >>= 1;
            }
            return binary;
        }
    }
}

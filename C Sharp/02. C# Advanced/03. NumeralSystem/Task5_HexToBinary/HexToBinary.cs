using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_HexToBinary
{
    class HexToBinary
    {
        static void Main()
        {
            string hexNumber = Console.ReadLine();
            string binaryNumber = ConvertHexToBinary(hexNumber);
            Console.WriteLine(binaryNumber);
        }

        static string ConvertHexToBinary(string hexNumber)
        {
            int number = 0;
            string binary = string.Empty;
            // Convert from Hex(1 digit) to Binary(4 digits) directly
            for (int i = 0; i < hexNumber.Length; i++)
            {
                // Convert from (0 - 9)hex to binary
                if (hexNumber[i] >= '0' && hexNumber[i] <= '9')
                {
                    number = hexNumber[i] - '0';
                }
                // Convert from (A - F)hex to binary
                else
                {
                    number = (hexNumber[i] - 'A') + 10;
                }
                // Save the binary number in string with four digits (fill with zeros)
                if (i > 0)
                {
                    binary += Convert.ToString(number, 2).PadLeft(4, '0');
                }
                // Save the first fourth binary number without zeros at the beginning
                else
                {
                    binary = Convert.ToString(number, 2);
                }
            }
            return binary;
        }
    }
}

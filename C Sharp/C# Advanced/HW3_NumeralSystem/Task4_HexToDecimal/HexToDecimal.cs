using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_HexToDecimal
{
    class HexToDecimal
    {
        static void Main()
        {
            string hexNumber = Console.ReadLine();
            long decimalNumber = ConvertHexToDecimal(hexNumber);
            Console.WriteLine(decimalNumber);
        }

        private static long ConvertHexToDecimal(string hexNumber)
        {
            long sum = 0;
            for (int i = hexNumber.Length - 1; i >= 0; i--)
            {
                
                if (hexNumber[i] >= '0' && hexNumber[i] <= '9')
                {
                    sum += (long)Math.Pow(16, (hexNumber.Length - i - 1)) * (hexNumber[i] - '0');
                }
                else
                {
                    sum += (long)Math.Pow(16, (hexNumber.Length - i - 1)) * ((hexNumber[i] - 'A') + 10);
                }
            }
            return sum;
        }
    }
}

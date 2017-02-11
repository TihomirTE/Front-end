using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task14_HexToDecimal
{
    class HexToDecimal
    {
        static void Main()
        {
            string hex = Console.ReadLine();
            double number = 0;
            for (int i = hex.Length - 1; i >= 0; i--)
            {
                var digit =hex[i];
                if (digit >= 48 && digit <= 57)
                {
                    number += (digit - 48) * Math.Pow(16, (hex.Length - 1) - i);
                }
                else
                {
                    switch (digit)
                    {
                        case 'A': number += (digit - 55) * Math.Pow(16, (hex.Length - 1) - i); break;
                        case 'B': number += (digit - 55) * Math.Pow(16, (hex.Length - 1) - i); break;
                        case 'C': number += (digit - 55) * Math.Pow(16, (hex.Length - 1) - i); break;
                        case 'D': number += (digit - 55) * Math.Pow(16, (hex.Length - 1) - i); break;
                        case 'E': number += (digit - 55) * Math.Pow(16, (hex.Length - 1) - i); break;
                        case 'F': number += (digit - 55) * Math.Pow(16, (hex.Length - 1) - i); break;
                        default: break;
                    }
                }
            }
            Console.WriteLine(number);
        }
    }
}

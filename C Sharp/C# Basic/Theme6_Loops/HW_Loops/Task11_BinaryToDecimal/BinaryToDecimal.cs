using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11_BinaryToDecimal
{
    class BinaryToDecimal
    {
        static void Main()
        {
            string binary = Console.ReadLine();
            double number = 0;
            for (int i = binary.Length -1 ; i >= 0; i--)
            {
                int digit = Convert.ToInt32(binary[i]);
                if (digit == 49)
                {
                    number += Math.Pow(2, (binary.Length - 1) - i);
                }
            }
            Console.WriteLine(number);
        }
    }
}

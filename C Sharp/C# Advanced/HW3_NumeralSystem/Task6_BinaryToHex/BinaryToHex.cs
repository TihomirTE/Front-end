using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_BinaryToHex
{
    class BinaryToHex
    {
        static void Main()
        {

            string binary = Console.ReadLine();
            //string hex = Convert.ToInt64(binary, 2).ToString("X"); -> it can be solved only with this code :)

            // 1.2v 
            string hex = ConvertBinaryToHex(binary);

        }

        private static string ConvertBinaryToHex(string binary)
        {
            int num = 0;
            string hex = string.Empty;
            int counter = 0;
            for (int i = binary.Length - 1; i >= 0; i --)
            {
                if ((i + 1) % 4 == 0 && i != binary.Length - 1)
                {
                    hex += Convert.ToString(num, 16);
                }
                if ((i + 1) % 4 == 0)
                {
                    num = 0;
                    
                    num = (binary[i] & 1) * 8;
                }
                else
                {
                    num += (binary[i] & 1) * (int)Math.Pow(2, (i % ));
                }
                
            }
            return hex;
        }
    }
}

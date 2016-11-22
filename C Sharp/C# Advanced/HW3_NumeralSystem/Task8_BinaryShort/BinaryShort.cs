using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_BinaryShort
{
    class BinaryShort
    {
        static void Main()
        {
            short number = short.Parse(Console.ReadLine());
            string binary = string.Empty;
            binary = Convert.ToString(number, 2).PadLeft(16, '0');
            Console.WriteLine(binary);
        }
    }
}

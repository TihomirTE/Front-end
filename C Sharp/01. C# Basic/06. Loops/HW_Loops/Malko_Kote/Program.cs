using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malko_Kote
{
    class Program
    {
        static void Main(string[] args)
        {
            // read input
            int size = int.Parse(Console.ReadLine());
            char ch  = (char)Console.Read();

            // (size + 8) / 2 -> numbers of cols
            int maxCol = (size + 8) / 2;
            for (int row = 0; row < size; row++)
            {

            }

            Console.WriteLine(size);
            Console.WriteLine(ch);
        }
    }
}

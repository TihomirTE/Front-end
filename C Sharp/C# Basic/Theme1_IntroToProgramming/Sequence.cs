using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence
{
    class Sequence
    {
        static void Main(string[] args)
        {
            for (int i = 2, k = -3; i <= 1000; i+=2, k-=2)
            {
                Console.WriteLine(i);
                Console.WriteLine(k);
            }

        }
    }
}

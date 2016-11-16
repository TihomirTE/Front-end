using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Mutant
{
    class Mutant
    {
        static void Main()
        {
            long trees = long.Parse(Console.ReadLine());
            long branch = long.Parse(Console.ReadLine());
            long squar = long.Parse(Console.ReadLine());
            long tails = long.Parse(Console.ReadLine());

            double total = trees * branch * squar * tails;
            if (total % 2 == 0)
            {
                total *= 376439;
            }
            else
            {
                total /= 7;
            }
            Console.WriteLine("{0:f3}", total);
        }
    }
}

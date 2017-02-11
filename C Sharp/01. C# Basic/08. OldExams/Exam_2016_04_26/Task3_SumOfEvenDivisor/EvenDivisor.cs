using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SumOfEvenDivisor
{
    class EvenDivisor
    {
        static void Main()
        {
            int i = 2;

            for (i = 1; i <= 5; i++)
            {
                switch (i)
                {
                    case 1: i++; break;
                    case 2: i--; break;
                    case 3: ++i; break;
                    case 4: i--; break;
                    default:i++;
                        break;
                }
            }
            Console.WriteLine(i);
        }
       
    }
}

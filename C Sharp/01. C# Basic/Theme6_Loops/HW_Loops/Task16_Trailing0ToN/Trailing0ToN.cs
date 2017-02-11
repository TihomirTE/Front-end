using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task16_Trailing0ToN
{
    class Trailing0ToN
    {
        static void Main()
        {
            /*int timesZero = 0;

            for (int power5 = 5; power5 <= n; power5 *= 5)
                timesZero += n / power5;*/

            int n = int.Parse(Console.ReadLine());

            int counter = 0;
            for (int i = 5; i <= n; i *= 5)
            {
                counter += n / i;
            }
            Console.WriteLine(counter);
        }
    }
}

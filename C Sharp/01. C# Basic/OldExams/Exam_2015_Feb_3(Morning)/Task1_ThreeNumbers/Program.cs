using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_ThreeNumbers
{
    class ThreeNumbers
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int bigger = 0;
            int smaller = 0;
            double avg = (a + b + c) / 3.0;

            bigger = Math.Max(a, b);
            smaller = Math.Min(a, b);
            Console.WriteLine(Math.Max(bigger, c));
            Console.WriteLine(Math.Min(smaller, c));
            Console.WriteLine("{0:f2}", avg);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Triangle
{
    class Triangle
    {
        static void Main()
        {
            double side = double.Parse(Console.ReadLine());
            double altitude = double.Parse(Console.ReadLine());
            double surface = (side * altitude) / 2;
            Console.WriteLine("{0:f2}", surface);
        }
    }
}

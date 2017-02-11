using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_TriangleTwoSidesAndAngle
{
    class TriangleTwoSidesAndAngle
    {
        static void Main()
        {
            double side1 = double.Parse(Console.ReadLine());
            double side2 = double.Parse(Console.ReadLine());
            double angle = double.Parse(Console.ReadLine());

            // convert degrees to radians
            double radians = (angle * Math.PI) / 180;
            double area = ((side1 * side2) * Math.Sin(radians)) / 2;
            Console.WriteLine("{0:f2}", area);
        }
    }
}

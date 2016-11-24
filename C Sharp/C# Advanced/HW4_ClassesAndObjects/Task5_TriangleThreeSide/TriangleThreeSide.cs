using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_TriangleThreeSide
{
    class TriangleThreeSide
    {
        static void Main()
        {
            double side1 = double.Parse(Console.ReadLine());
            double side2 = double.Parse(Console.ReadLine());
            double side3 = double.Parse(Console.ReadLine());

            double halfPerimeter = (side1 + side2 + side3) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - side1)
                * (halfPerimeter - side2) * (halfPerimeter - side3));
            Console.WriteLine("{0:f2}", area);
        }
    }
}

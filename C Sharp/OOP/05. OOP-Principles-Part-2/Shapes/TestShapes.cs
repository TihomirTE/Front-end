using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class TestShapes
    {
        public static void Main()
        {
            List<Shapes> shapes = new List<Shapes>
            {
                new Rectangle (10, 5),
                new Square (7),
                new Triangle(12, 5)
            };

            foreach (var shape in shapes)
            {
                var shapeSurface = shape.CalculateSurface();
                Console.WriteLine("{0} has surface: {1}", shape.GetType().Name,
                    shape.CalculateSurface());
            }
        }
    }
}

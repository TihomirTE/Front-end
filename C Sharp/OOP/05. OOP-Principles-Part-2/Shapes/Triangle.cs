using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle : Shapes
    {
        public Triangle(int width, int height) 
            : base(width, height)
        {
        }

        public override int CalculateSurface()
        {
            int surface = (height * width) / 2;
            return surface;
        }
    }
}

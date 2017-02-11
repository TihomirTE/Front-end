using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Rectangle : Shapes
    {
        public Rectangle(int width, int height) 
            : base(width, height)
        {
        }

        public override int CalculateSurface()
        {
            int surface = width * height;
            return surface;
        }
    }
}

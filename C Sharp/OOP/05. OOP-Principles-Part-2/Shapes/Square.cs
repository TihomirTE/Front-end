using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : Shapes
    {
        public Square(int width) 
            : base(width, width)
        {
        }

        public override int CalculateSurface()
        {
            int surface = width * 4;
            return surface;
        }
    }
}

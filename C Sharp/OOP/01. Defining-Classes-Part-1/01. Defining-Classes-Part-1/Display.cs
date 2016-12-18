using System;

namespace _01.Defining_Classes_Part_1
{
    public class Display
    {
        // fields
        private double? size = null;
        private int? colors = null;

        // constructors
        public Display()
        {

        }

        public Display(double? size)
        {
            this.size = size;
        }

        public Display(int? colors, double? size)
        {
            this.colors = colors;
            this.size = size;
        }

        // properties
        public double? Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }
        public int? Colors
        {
            get
            {
                return this.colors;
            }
            set
            {
                this.colors = value;
            }
        }

    }
}

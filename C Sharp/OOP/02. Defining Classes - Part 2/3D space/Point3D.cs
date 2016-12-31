namespace _3D_space
{
    public struct Point3D
    {
        // coordinates
        private decimal x;
        private decimal y;
        private decimal z;
        
        // strarting point of the Coordinated System
        private static readonly Point3D startPointOfCoordSystem = new Point3D(0, 0, 0);
        
        /// <summary>
        /// constructor of point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point3D (decimal x, decimal y, decimal z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

       
        // properties
        public decimal X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public decimal Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public decimal Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        //start of coordination system
        public static Point3D StartPointOfCoordSystem
        {
            get
            {
                return startPointOfCoordSystem;
            }
        }
        
        /// <summary>
        /// Override toString Method
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns> The coordinates of a point </returns>
        public string ToString(decimal x, decimal y, decimal z)
        {
            return string.Format("Point: x= {0}, y= {1}, z= {2}", this.X, this.Y, this.Z);
        } 
    }
}

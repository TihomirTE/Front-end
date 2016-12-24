namespace _3D_space
{
    public struct Point3D
    {
        
        /// <summary>
        /// strarting point of the Coordinated System
        /// </summary>
        private static readonly Point3D startPointOfCoordSystem = new Point3D(0, 0, 0);
        
        /// <summary>
        /// constructor of point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point3D (decimal x, decimal y, decimal z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

       
        /// <summary>
        /// properties
        /// </summary>
        public decimal X{ get; set; }

        public decimal Y{ get; set; }

        public decimal Z{ get; set; }


        public static Point3D StartPointOfCoordSystem
        {
            get
            {
                return startPointOfCoordSystem;
            }
        }
        
        /// <summary>
        /// ToString Method
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

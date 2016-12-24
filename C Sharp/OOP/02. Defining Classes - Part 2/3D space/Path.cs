namespace _3D_space
{
    using System.Collections.Generic;

    public class Path
    {
        /// <summary>
        /// Holding sequence of points
        /// </summary>
        public List<Point3D> seqOfPoints = new List<Point3D>();

        public void AddPoint(Point3D point)
        {
            seqOfPoints.Add(point);
        }
    }
}

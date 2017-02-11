namespace _3D_space
{
    using System.Collections.Generic;

    public class Path
    {
        // Holding sequence of points
        public List<Point3D> seqOfPoints = new List<Point3D>();

        // add point
        public void AddPoint(Point3D point)
        {
            seqOfPoints.Add(point);
        }

        // remove point
        public void RemovePoint(Point3D point)
        {
            seqOfPoints.Remove(point);
        }
    }
}

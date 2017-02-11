namespace _3D_space
{
    using System;

    public static class DistanseBetweenTwoPoints
    {
        /// <summary>
        /// Calculating the distance between two points in 3D space
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <returns> Distance between tow points </returns>
        public static decimal CalculateDistance(Point3D pointA, Point3D pointB)
        {
            // distance between the points in every dimension
            decimal diffX = pointA.X - pointB.X;
            decimal diffY = pointA.Y - pointB.Y;
            decimal diffZ = pointA.Z - pointB.Z;

            double dist = Math.Sqrt((double)((diffX * diffX) + (diffY * diffY) + (diffZ * diffZ)));
            return (decimal)dist;
        }     

    }
}

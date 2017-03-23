namespace CohesionAndCoupling
{
    using System;

    public class CalculateDistanceUtils
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance2D = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance2D;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance3D = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) + ((z2 - z1) * (z2 - z1)));
            return distance3D;
        }
    }
}

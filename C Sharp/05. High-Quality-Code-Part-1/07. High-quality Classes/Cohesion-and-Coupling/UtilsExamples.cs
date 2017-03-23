namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileNameUtils.GetFileExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                                CalculateDistanceUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                                CalculateDistanceUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Figure3D figure3D = new Figure3D(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", figure3D.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", figure3D.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", figure3D.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", figure3D.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", figure3D.CalcDiagonalYZ());
        }
    }
}

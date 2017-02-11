namespace _3D_space
{
    using System.IO;

    public static class PathStorage
    {
        // IO files
        private static readonly StreamReader readFile = new StreamReader(@"..\..\InputCoordinates.txt");
        private static readonly StreamWriter writeFile = new StreamWriter(@"..\..\OutputCoordinates.txt");

        // Reading file
        public static Path LoadFile()
        {
            Path currentPath = new Path();

            // "using" -> the file will close reaching the end of this code
            using (readFile)
            {
                string line = readFile.ReadLine();

                while (line != null)
                {
                    string[] numbers = line.Split(' ');

                    // extract the coordinates of the point in 3D space
                    decimal x = decimal.Parse(numbers[0]);
                    decimal y = decimal.Parse(numbers[1]);
                    decimal z = decimal.Parse(numbers[2]);

                    Point3D currentPoint = new Point3D(x, y, z);
                    currentPath.AddPoint(currentPoint);
                    line = readFile.ReadLine(); // update the line in the file
                }
            }
            return currentPath;
        }

        // Write in the file
        public static void SaveFile(Path currentPath)
        {
            using (writeFile)
            {
                foreach (var point in currentPath.seqOfPoints)
                {
                    string writeFileLine = string.Format("{0} {1} {2}", point.X, point.Y, point.Z);
                    writeFile.WriteLine(writeFileLine);
                }
            }
        }
    }
}

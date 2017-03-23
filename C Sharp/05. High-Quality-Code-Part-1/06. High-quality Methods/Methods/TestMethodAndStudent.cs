namespace Methods
{
    using System;

    public class TestMethodAndStudent
    {
        public static void Main()
        {
            Console.WriteLine(Methods.CalcTriangleArea(3, 4, 5));

            Console.WriteLine(Methods.ConvertNumberToDigit(5));

            Console.WriteLine(Methods.FindMaxNumber(5, -1, 3, 2, 14, 2, 3));

            Methods.PrintNumberWithPrecision(1.3);
            Methods.PrintNumberAsPercentage(0.75);
            Methods.PrintNumberAlignedRight(2.30);

            double firstPointX = 3;
            double firstPointY = -1;
            double secondPointX = 3;
            double secondPointY = 2.5;

            Console.WriteLine(Methods.CalcDistance(firstPointX, firstPointY, secondPointX, secondPointY));

            bool isHorizontal = firstPointY == secondPointY;
            bool isVertical = firstPointX == secondPointX;

            Console.WriteLine(Methods.CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + isHorizontal);
            Console.WriteLine("Vertical? " + isVertical);

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 17), "From Sofia");
            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 3), "From Vidin, gamer, high results");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}

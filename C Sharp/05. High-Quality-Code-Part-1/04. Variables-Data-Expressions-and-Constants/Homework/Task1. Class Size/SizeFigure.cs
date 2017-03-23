namespace Task1.Class_Size
{
    using System;

    public class SizeFigure
    {
        private double width;
        private double heigth;

        public SizeFigure(double width, double heigth)
        {
            this.width = width;
            this.heigth = heigth;
        }

        public static SizeFigure GetRotatedSize(SizeFigure size, double rotatedAngel)
        {
            var widthCos = Math.Abs(Math.Cos(rotatedAngel)) * size.width;
            var widthSin = Math.Abs(Math.Sin(rotatedAngel)) * size.heigth;
            var width = widthCos + widthSin;

            var heigthSin = Math.Abs(Math.Sin(rotatedAngel)) * size.width;
            var heigthCos = Math.Abs(Math.Cos(rotatedAngel)) * size.heigth;
            var heigth = heigthSin + heigthCos;

            var result = new SizeFigure(width, heigth);

            return result;
        }
    }
}

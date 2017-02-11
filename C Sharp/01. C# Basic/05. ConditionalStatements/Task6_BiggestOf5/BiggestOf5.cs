using System;


namespace Task6_BiggestOf5
{
    class BiggestOf5
    {
        static void Main()
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());
            double num4 = double.Parse(Console.ReadLine());
            double num5 = double.Parse(Console.ReadLine());

            double max = double.MinValue;
            if (num1 > max)
            {
                max = num1;
            }
            if (num2 > max)
            {
                max = num2;
            }
            if (num3 > max)
            {
                max = num3;
            }
            if (num4 > max)
            {
                max = num4;
            }
            if (num5 > max)
            {
                max = num5;
            }
            Console.WriteLine(max);
        }
    }
}

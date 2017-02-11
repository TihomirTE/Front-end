using System;


namespace ComparingFloats
{
    class ComparingFloats
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double diff = Math.Abs(a - b);

            if (diff == 0 || diff < 0.000001)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}

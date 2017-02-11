using System;

namespace Task1_ExcgangeIfGreater
{
    class ExchangeIfGreater
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double curent = 0;

            if (a > b)
            {
                curent = a;
                a = b;
                b = curent;
            }
            Console.WriteLine("{0} {1}", a, b);
        }
    }
}

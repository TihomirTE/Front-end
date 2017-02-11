using System;


namespace Task1_NumbersFrom1ToN
{
    class NumbersFrom1ToN
    {
        static void Main()
        {
            uint num = Convert.ToUInt32(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }
    }
}

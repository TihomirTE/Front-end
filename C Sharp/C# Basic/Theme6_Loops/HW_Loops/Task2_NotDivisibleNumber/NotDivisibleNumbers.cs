using System;


namespace Task2_NotDivisibleNumber
{
    class NotDivisibleNumbers
    {
        static void Main()
        {
            uint num = Convert.ToUInt32(Console.ReadLine());
            //string input = Console.ReadLine();

            //bool isNum = uint.TryParse(input, out num);

            for (int i = 1; i <= num; i++)
            {
                if (i % 3 == 0 || i % 7 == 0)
                {
                    continue;
                }
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }
    }
}

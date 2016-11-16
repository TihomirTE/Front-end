using System;


namespace Task7_Sort3Numbers
{
    class Sort3Numbers
    {
        static void Main()
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());

            if (num1 > num2 && num1 > num3)
            {
                if (num2 > num3 )
                {
                    Console.WriteLine("{0} {1} {2}", num1, num2, num3);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", num1, num3, num2);
                }
            }
            else if (num2 > num1 && num2 > num3)
            {
                if (num1 > num3)
                {
                    Console.WriteLine("{0} {1} {2}", num2, num1, num3);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", num2, num3, num1);
                }
            }
            else
            {
                if (num1 > num2)
                {
                    Console.WriteLine("{0} {1} {2}", num3, num1, num2);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", num3, num2, num1);
                }
            }
        }
    }
}

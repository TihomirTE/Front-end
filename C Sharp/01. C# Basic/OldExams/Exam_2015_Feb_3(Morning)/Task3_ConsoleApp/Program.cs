using System;
using System.Numerics;

namespace Task3_ConsoleApp
{
    class ConsoleApp
    {
        static void Main()
        {
            int counter = 0;
            BigInteger sum = 1;
            BigInteger secondSum = 1;

            while (true)
            {
                string input = Console.ReadLine();
                long number = 0;
                bool result = long.TryParse(input, out number);
                if (result)
                {
                    long digit = 0;
                    if ((counter > 10) && (counter % 2 == 1))
                    {
                        while (number > 0)
                        {
                            digit = number % 10;
                            if (digit != 0)
                            {
                                secondSum *= digit;
                            }
                            number /= 10;
                        }
                    }

                    else if ((counter % 2 == 1) && (counter <= 10))
                    {
                        while (number > 0)
                        {
                            digit = number % 10;
                            if (digit != 0)
                            {
                                sum *= digit;
                            }
                            number /= 10;
                        }
                    }
                    counter++;
                }
                else
                    break;
            }
            if (counter > 10)
            {
                Console.WriteLine(sum);
                Console.WriteLine(secondSum);
            }
            else
                Console.WriteLine(sum);
        }
    }
}

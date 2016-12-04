using System;
using System.Numerics;

namespace Task7_OneSystemToAnyOther
{
    class Program
    {
        static void Main()
        {
            string numeralSystem1 = Console.ReadLine();  
            string number1 = Console.ReadLine();
            string numeralSystem2 = Console.ReadLine();
            BigInteger decimalNumber = ConvertSystem1ToDecimal(number1, numeralSystem1);
            string number2 = ConvertDecimalToSystem2(decimalNumber, numeralSystem2);
            Console.WriteLine(number2);
        }

        private static string ConvertDecimalToSystem2(BigInteger decimalNumber, string numeralSystem2)
        {
            int system2 = Convert.ToInt32(numeralSystem2);
            int remainder = 0;
            string number2 = string.Empty;
            while (decimalNumber > 0)
            {
                remainder = (int)(decimalNumber % system2);
                switch (remainder)
                {
                    case 10: number2 = "A" + number2; break;
                    case 11: number2 = "B" + number2; break;
                    case 12: number2 = "C" + number2; break;
                    case 13: number2 = "D" + number2; break;
                    case 14: number2 = "E" + number2; break;
                    case 15: number2 = "F" + number2; break;
                    default: number2 = remainder + number2; break;
                }
                decimalNumber /= system2;
            }
            return number2;
        }

        private static BigInteger ConvertSystem1ToDecimal(string number1, string numeralSystem1)
        {
            BigInteger sum = 0;
            int system1 = int.Parse(numeralSystem1);
            for (int i = number1.Length - 1; i >= 0; i--)
            {
                if (number1[i] >= '0' && number1[i] <= '9') // digit is between 0 and 9 inclusive
                {
                    sum += BigInteger.Pow(system1, (number1.Length - i - 1)) * (number1[i] - '0');
                }
                else  // digit is between 10 and 15 inclusive
                {
                    sum += BigInteger.Pow(system1, (number1.Length - i - 1)) * ((number1[i] - 'A') + 10);
                }
            }
            return sum; // the decimal number
        }
    }
}

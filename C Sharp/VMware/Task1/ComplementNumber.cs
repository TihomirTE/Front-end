using System;

namespace Task1
{
    public class ComplementNumber
    {
        public static void Main()
        {
            Console.Write("Y = ");
            int number = int.Parse(Console.ReadLine());
            string binary = ConvertDecimalToBitwiseInversion(number);
            int result = BinaryToDecimal(binary);
            Console.WriteLine("X = "+ result);
        }

        public static string ConvertDecimalToBitwiseInversion(int number)
        {
            string binary = "";
            int digit = 0;
            while (number > 0)
            {
                digit = (int)(number & 1);
                if (digit == 1)
                {
                    digit = 0;
                }
                else
                {
                    digit = 1;
                }
                binary = digit + binary;
                number >>= 1;
            }

            return binary;
        }

        public static int BinaryToDecimal(string binary)
        {
            int number = 0;
            int lenght = binary.Length - 1;

            for (int i = lenght; i >= 0; i--)
            {
                number += (binary[i] - '0') * (int)Math.Pow(2, (lenght - i));
            }

            return number;
        }
    }
}

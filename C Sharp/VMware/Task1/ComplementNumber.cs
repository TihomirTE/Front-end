using System;

namespace Task1
{
    /*
    Description:
    Given a positive integer you have to calculate its complement and return it.
    A complement number X is such number that is equal to the bitwise inversion of a number Y.
    Examples:- Y = 28(10) = 11100(2) -> bitwise inversion -> 00011(2) = 3(10) => X = 3 ,
     Y = 35(10) = 100011(2) -> bitwise inversion -> 011100(2) = 28(10) => X = 28,
     Y = 60(10) = 111100(2) -> bitwise inversion -> 000011(2) = 3(10) => X = 3
    */

    public class ComplementNumber
    {
        public static void Main()
        {
            Console.Write("Y = ");
            int number = int.Parse(Console.ReadLine());

            string binary = ConvertDecimalToBitwiseInversion(number);
            int result = ConvertBinaryToDecimal(binary);

            Console.WriteLine("X = "+ result);
        }

        public static string ConvertDecimalToBitwiseInversion(int number)
        {
            string binary = "";
            int digit = 0;

            while (number > 0)
            {
                digit = (int)(number & 1);

                // Bitwise inversion
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

        public static int ConvertBinaryToDecimal(string binary)
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

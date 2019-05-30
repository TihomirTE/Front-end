using System;
using System.Text;

namespace vsTests
{
    class Program
    {
        public static void Main()
        {
            char[] binary = Console.ReadLine().ToCharArray();
            // variant 1
            //string hex = Convert.ToInt64(binary, 2).ToString("X"); // -> it can be solved only with this code :)

            // Variant 2
            //1) convert Binary to Decimal
            long decimalNumber = ConvertBinaryToDecimal(binary);
            //2) convert Decimal to Hexadecimal
            string hex = ConvertDecimalToHex(decimalNumber);
            Console.WriteLine(hex);
        }

        private static long ConvertBinaryToDecimal(char[] arr)
        {
            long number = 0;
            for (long i = arr.Length - 1; i >= 0; i--)
            {
                number += (arr[i] - '0') * (long)Math.Pow(2, (arr.Length - i - 1));
            }
            
            return number;
        }

        static string ConvertDecimalToHex(long number)
        {
            StringBuilder hexNumber = new StringBuilder();
            
            while (number > 0)
            {
                int remainder = (int)(number % 16);
                if (remainder < 10)
                {
                    hexNumber.Insert(0, remainder);
                }
                else
                {
                    switch (remainder)
                    {
                        case 10:
                            hexNumber.Insert(0, "A");
                        break;
                        case 11:
                            hexNumber.Insert(0, "B");
                         break;
                        case 12:
                            hexNumber.Insert(0, "C");
                        break;
                        case 13:
                            hexNumber.Insert(0, "D");
                        break;
                        case 14: 
                            hexNumber.Insert(0, "E");
                        break;
                        case 15: 
                            hexNumber.Insert(0, "F");
                        break;
                        
                        default:
                         break;
                    }
                }
                number /= 16;
            }

            return hexNumber.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01.DeCatCoding
{
    class DeCatCoding
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            BigInteger[] number = new BigInteger[input.Length];
            string[] result = new string[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                number[i] = ConvertToDecimal(input[i]);
                result[i] = ConvertTo26based(number[i]);
            }
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }
            Console.WriteLine();
        }

        private static string ConvertTo26based(BigInteger integer)
        {
            StringBuilder newSystem = new StringBuilder();
            BigInteger currentNum = 0;
            char currentLetter;
            while (integer > 0)
            {
                currentNum = integer % 26;
                currentLetter = (char)(currentNum + 'a');
                newSystem.Insert(0, currentLetter);
                integer /= 26;
            }
            return newSystem.ToString();
        }

        private static BigInteger ConvertToDecimal(string input)
        {
            BigInteger num = 0;
            for (int i = 0; i < input.Length; i++)
            {
                num += (int)(input[i] - 'a') * BigInteger.Pow(21, (input.Length - i - 1));
            }
            return num;
        }
    }
}

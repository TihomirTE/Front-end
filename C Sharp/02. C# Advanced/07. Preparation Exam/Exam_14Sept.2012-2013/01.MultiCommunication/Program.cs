using System;
using System.Numerics;
using System.Text;


namespace _01.MultiCommunication
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string num = ConvertToNum(input);
            ConvertToDecimal(num);
        }

        private static void ConvertToDecimal(string num)
        {
            BigInteger number = 0;
            int count = 0;
            double pow = 0;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                if (num[i] == 'A')
                {
                    pow = Math.Pow(13, count) * 10;
                }
                else if (num[i] == 'B')
                {
                    pow = Math.Pow(13, count) * 11;
                }
                else if (num[i] == 'C')
                {
                    pow = Math.Pow(13, count) * 12;
                }
                else
                {
                    pow = Math.Pow(13, count) * (num[i] - '0');
                }
                number += (long)pow;
                count++;
            }
            Console.WriteLine(number);
        }

        private static string ConvertToNum(string input)
        {
            int startIndex = 0;
            StringBuilder strNumber = new StringBuilder();
            while (startIndex < input.Length)
            {
                // take 3 letters every time
                string intNumber = input.Substring(startIndex, 3);
                switch (intNumber)
                {
                    case "CHU":strNumber.Append("0"); break;
                    case "TEL":strNumber.Append("1"); break;
                    case "OFT":strNumber.Append("2"); break;
                    case "IVA":strNumber.Append("3"); break;
                    case "EMY":strNumber.Append("4"); break;
                    case "VNB":strNumber.Append("5"); break;
                    case "POQ":strNumber.Append("6"); break;
                    case "ERI":strNumber.Append("7"); break;
                    case "CAD":strNumber.Append("8"); break;
                    case "K-A":strNumber.Append("9"); break;
                    case "IIA":strNumber.Append("A"); break;
                    case "YLO":strNumber.Append("B"); break;
                    case "PLA":strNumber.Append("C"); break;
                    default: break;
                }
                startIndex += 3;
            }
            return strNumber.ToString();
        }
    }
}

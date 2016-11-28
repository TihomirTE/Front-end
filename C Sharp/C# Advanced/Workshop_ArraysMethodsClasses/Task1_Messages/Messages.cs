using System;
using System.Numerics;


namespace Task1_Messages
{
    class Messages
    {
        static void Main()
        {
            // input
            string number1 = Console.ReadLine();
            string symbol = Console.ReadLine();
            string number2 = Console.ReadLine();

            BigInteger decimalNumber1 =  ConvertToDecimal(number1);
            BigInteger decimalNumber2 = ConvertToDecimal(number2);
            BigInteger result = CalculateTheNumber(decimalNumber1, decimalNumber2, symbol);
            ConvertTheResult(result);
        }

        private static void ConvertTheResult(BigInteger result)
        {
            string finalNumber = string.Empty;
            string rest = result.ToString();
            for (int i = 0; i < rest.Length; i++)
            {
                // Convert to the GeorgeTheGreat numeral system
                switch (rest[i])
                {
                    case '0': finalNumber += "cad"; break;
                    case '1': finalNumber += "xoz"; break;
                    case '2': finalNumber += "nop"; break;
                    case '3': finalNumber += "cyk"; break;
                    case '4': finalNumber += "min"; break;
                    case '5': finalNumber += "mar"; break;
                    case '6': finalNumber += "kon"; break;
                    case '7': finalNumber += "iva"; break;
                    case '8': finalNumber += "ogi"; break;
                    case '9': finalNumber += "yan"; break;
                    default: break;
                }
            }
            // print the result
            Console.WriteLine(finalNumber);
        }

        private static BigInteger CalculateTheNumber(BigInteger decimalNumber1, BigInteger decimalNumber2, string symbol)
        {
            BigInteger result = new BigInteger();
            if (symbol == "+")
            {
                result = decimalNumber1 + decimalNumber2;
            }
            else
            {
                result = decimalNumber1 - decimalNumber2;
            }
            return result;
        }

        private static BigInteger ConvertToDecimal(string number)
        {
            int startIndex = 0;
            string strNumber = string.Empty;
            while (startIndex < number.Length)
            {  
                // take 3 letters every time
                string intNumber = number.Substring(startIndex, 3); 
                switch (intNumber)
                {
                    case "cad": strNumber += 0; break;
                    case "xoz": strNumber += 1; break;
                    case "nop": strNumber += 2; break;
                    case "cyk": strNumber += 3; break;
                    case "min": strNumber += 4; break;
                    case "mar": strNumber += 5; break;
                    case "kon": strNumber += 6; break;
                    case "iva": strNumber += 7; break;
                    case "ogi": strNumber += 8; break;
                    case "yan": strNumber += 9; break;
                    default: break;
                }
                startIndex += 3; // update the position
            }
            BigInteger decimalNumber = BigInteger.Parse(strNumber);
            return decimalNumber;
        }
    }
}

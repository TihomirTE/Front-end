using System;
using System.Text;


namespace DecodeAndEncrypt
{
    class Program
    {
        static void Main()
        {
            // input
            string message = Console.ReadLine();

            int lenghtOfCypher = GetLenghtCypher(message);

            string encodeMessage = EncodeMessageAndCypher(message, lenghtOfCypher);

            string cypher = GetLenghtCypher(encodeMessage, lenghtOfCypher);

            string extractMessage = GetLenghtMessage(encodeMessage, cypher);

            Decode(cypher, extractMessage);
        }

        private static void Decode(string cypher, string extractMessage)
        {
            var arr = extractMessage.ToCharArray();
            int lenght = Math.Max(cypher.Length, extractMessage.Length);
            for (int i = 0; i < lenght; i++)
            {
                var code1 = cypher[i % cypher.Length] - 'A';
                var code2 = arr[i % extractMessage.Length] - 'A';
                var code = (char)((code1 ^ code2) + 'A');
                arr[i % extractMessage.Length] = code;
            }
            string result = string.Join("", arr);
            Console.WriteLine(result);
        }

        private static string GetLenghtMessage(string encodeMessage, string cypher)
        {
            int lenght = encodeMessage.Length - cypher.Length;
            string extractMessage = encodeMessage.Substring(0, lenght);
            return extractMessage;
        }

        private static string GetLenghtCypher(string encodeMessage, int lenghtOfCypher)
        {
            int start = encodeMessage.Length - lenghtOfCypher;
            string cypher = encodeMessage.Substring(start, lenghtOfCypher);
            return cypher;
        }

        private static string EncodeMessageAndCypher(string message, int lenghtCypher)
        {
            StringBuilder encodeMessage = new StringBuilder();
            int counter = 0;
            char letter;
            int lenght = lenghtCypher.ToString().Length;
            while (true)
            {
                letter = message[counter];
                if (counter == message.Length - lenght)
                {
                    break;
                }
                if (letter > 48 && letter < 57)
                {
                    encodeMessage.Append(new string(message[counter + 1], (int.Parse)(letter.ToString()) - 1));
                }
                else
                {
                    encodeMessage.Append(message[counter]);
                }
                counter++;
            }
            return encodeMessage.ToString();
        }

        static int GetLenghtCypher(string message)
        {
            StringBuilder strNum = new StringBuilder();
            for (int i = message.Length - 1; i >= 0; i--)
            {
                char digit = message[i];
                if (char.IsNumber(digit))
                {
                    strNum.Insert(0, digit);
                }
                else
                {
                    break;
                }
            }
            string str = strNum.ToString();
            int number = int.Parse(str);
            return number;
        }
        }
}

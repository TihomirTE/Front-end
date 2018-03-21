using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Messages_In_Bottle
{
    public class Messages
    {
        private static List<KeyValuePair<char, string>> separateCipher = new List<KeyValuePair<char, string>>();
        private static string seqOfDigits = Console.ReadLine();
        private static List<string> result = new List<string>();

        public static void Main()
        {
            string cipher = Console.ReadLine();
            SeparateLettersAndDigits(cipher);
            Solve(0, new StringBuilder());

            Console.WriteLine(result.Count);
            result.Sort();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }

        private static void Solve(int seqOfDigitsIndex, StringBuilder sb)
        {
            if (seqOfDigitsIndex == seqOfDigits.Length)
            {
                result.Add(sb.ToString());
                return;
            }

            foreach (var digit in separateCipher)
            {
                if (seqOfDigits.Substring(seqOfDigitsIndex).StartsWith(digit.Value))
                {
                    sb.Append(digit.Key);
                    Solve(seqOfDigitsIndex + digit.Value.Length, sb);
                    sb.Remove(sb.Length - 1, 1);

                    // It's the same for removing the element
                    //sb.Length--;
                }
            }
        }

        private static void SeparateLettersAndDigits(string cipher)
        {
            int len = cipher.Length;
            char key = '\0';
            StringBuilder value = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                if (cipher[i] >= 'A' && cipher[i] <= 'Z')
                {
                    if (key != '\0')
                    {
                        separateCipher.Add(new KeyValuePair<char, string>(key, value.ToString()));
                        value.Clear();
                    }

                    key = cipher[i];
                }
                else
                {
                    value.Append(cipher[i]);
                }
            }

            if (key != '\0')
            {
                separateCipher.Add(new KeyValuePair<char, string>(key, value.ToString()));
                value.Clear();
            }
        }
    }
}

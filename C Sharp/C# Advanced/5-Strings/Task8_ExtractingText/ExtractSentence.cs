using System;
using System.Text;

namespace Task8_ExtractingText
{
    class ExtractSentence
    {
        static void Main()
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            int indexDot = text.IndexOf(".");
            int indexStart = 0;
            StringBuilder output = new StringBuilder();
            while (indexDot != -1)
            {
                int lenght = (indexDot - indexStart);
                string sentence = text.Substring(indexStart, lenght);
                int indexWord = sentence.IndexOf(" " + word + " ");
                if (indexWord != -1 || sentence.StartsWith(word + " ")
                    || sentence.EndsWith(" " + word))
                {
                    string trimSentence = sentence.Trim();
                    output.Append(sentence + ".");
                }
                indexStart = indexDot + 1;
                // check for the next letter
                indexDot = text.IndexOf(".", indexDot + 1);
            }
            Console.WriteLine(output);
        }
    }
}

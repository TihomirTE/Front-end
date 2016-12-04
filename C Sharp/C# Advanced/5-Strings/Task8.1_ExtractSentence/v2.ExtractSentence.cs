using System;
using System.Text;

namespace _08.ExtractSentences
{
    class Program
    {
        static void Main(string[] args)
        {
            // input
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            string[] sentences = text.Split('.');
            StringBuilder nonLetter = new StringBuilder();
            StringBuilder result = new StringBuilder();

            foreach (var sentence in sentences)
            {
                nonLetter.Clear();
                for (int i = 0; i < sentence.Length; i++)
                {
                    if (char.IsLetter(sentence[i]) == false)
                    {
                        // adding Non-Letters symbols
                        nonLetter.Append(sentence[i]); 
                    }
                }
                char[] splitChars = nonLetter.ToString().ToCharArray();
                string[] words = sentence.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                
                if (Array.IndexOf(words, word) > -1)
                {
                    result.Append(sentence.Trim());
                    result.Append(". ");
                }
            }
            //print
            Console.WriteLine(result.ToString().Trim());
        }
    }
}

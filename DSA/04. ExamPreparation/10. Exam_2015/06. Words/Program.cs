using System;
using System.Linq;

namespace _06.Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();

            int[] prefixCounts = new int[word.Length + 1];
            int[] suffixCounts = new int[word.Length + 1];

            KMP(word, text, prefixCounts);

            word = new string(word.Reverse().ToArray());
            text = new string(text.Reverse().ToArray());

            KMP(word, text, suffixCounts);

            long result = prefixCounts[word.Length];
            for (int i = 1; i < word.Length; i++)
            {
                result += prefixCounts[i] * suffixCounts[word.Length - i];
            }

            Console.WriteLine(result);
        }

        private static void KMP(string word, string text, int[] counts)
        {
            int[] fl = new int[word.Length + 1];
            fl[0] = -1;
            fl[1] = 0;

            // precompute
            for (int i = 1; i < word.Length; i++)
            {
                int j = fl[i];

                while (j >= 0 && word[j] != word[i])
                {
                    j = fl[j];
                }

                fl[i + 1] = j + 1;
            }

            // search
            int matched = 0;
            for (int i = 0; i < text.Length; i++)
            {
                while (matched >= 0 && word[matched] != text[i])
                {
                    matched = fl[matched];
                }

                matched++;

                // count all partial occurences
                for (int j = matched; j >= 0; j = fl[j])
                {
                    counts[j]++;
                }

                if (matched == word.Length)
                {
                    matched = fl[matched];
                }
            }
        }
    }
}

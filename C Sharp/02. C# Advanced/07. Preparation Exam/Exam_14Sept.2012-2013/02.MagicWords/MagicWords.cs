using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MagicWords
{
    class MagicWords
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> words = new List<string>();
            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine());
            }
            List<string> orderList = new List<string>();
            orderList = Reorder(words, n);
            Print(orderList, n);
        }

        private static void Print(List<string> orderList, int n)
        {
            int biggestWord = 0;
            for (int i = 0; i < n; i++)
            {
                if (orderList[i].Length > biggestWord)
                {
                    biggestWord = orderList[i].Length;
                }
            }

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < biggestWord; i++)
            {
                foreach (var word in orderList)
                {
                    if (i < word.Length)
                    {
                        output.Append(word[i]);
                    }
                }
            }
            Console.WriteLine(output);
        }

        private static List<string> Reorder(List<string> words, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int pos = words[i].Length % (n + 1);
                words.Insert(pos, words[i]);
                if (pos < i)
                {
                    words.RemoveAt(i + 1);
                }
                else
                {
                    words.RemoveAt(i);
                }
            }
            return words;
        }
    }
}

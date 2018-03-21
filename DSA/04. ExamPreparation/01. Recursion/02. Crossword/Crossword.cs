using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Crossword
{
    public class Crossword
    {
        private static HashSet<string> allWords = new HashSet<string>();
        private static string[] words;
        private static string[] crossword;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            words = new string[2 * n];
            crossword = new string[n];

            for (int i = 0; i < 2 * n; i++)
            {
                words[i] = Console.ReadLine();
                allWords.Add(words[i]);
            }

            Array.Sort(words);
            FindCrossword(0);

            // if can't find solution
            Console.WriteLine("NO SOLUTION!");
        }

        private static void FindCrossword(int line)
        {
            if (line >= crossword.Length)
            {
                if (CheckVertical())
                {
                    PrintResult();
                    
                    // Exit the program when found the first solution
                    Environment.Exit(0);
                }

                return;
            }

            for (int i = 0; i < words.Length; i++)
            {
                crossword[line] = words[i];
                FindCrossword(line + 1);
                crossword[line] = null;

            }
        }

        private static bool CheckVertical()
        {
            StringBuilder currentWord = new StringBuilder();

            for (int i = 0; i < crossword.Length; i++)
            {
                currentWord.Clear();

                for (int j = 0; j < crossword.Length; j++)
                {
                    // get vertical word
                    currentWord.Append(crossword[j][i]);
                }

                if (!allWords.Contains(currentWord.ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        private static void PrintResult()
        {
            for (int i = 0; i < crossword.Length; i++)
            {
                Console.WriteLine(crossword[i]);
            }
        }
    }
}

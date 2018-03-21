using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Words
{
    public class Words
    {
        public static void Main()
        {
            int numOfLines = int.Parse(Console.ReadLine());

            var result = new Dictionary<string, int>();
            var words = new HashSet<string>();


            for (int i = 0; i < numOfLines; i++)
            {
                string input = Console.ReadLine();

                var regex = Regex.Split(input, @"[^\w0-9-]+")
                                   .Where(s => !String.IsNullOrWhiteSpace(s));

                var line = regex.ToArray();

                for (int j = 0; j < line.Length; j++)
                {
                    words.Add(line[j].ToLower());
                }
            }

            int numWords = int.Parse(Console.ReadLine());

            for (int i = 0; i < numWords; i++)
            {
                int value = 0;
                var key = Console.ReadLine();
                result.Add(key, value);
                var len = result.Keys.ToArray();
                var str = len[i].ToLower();

                foreach (var word in words)
                {
                    bool contains = true;
                    var wordToLow = word.ToLower();

                    for (int j = 0; j < str.Length; j++)
                    {
                        if (!wordToLow.Contains(str[j]))
                        {
                            contains = false;
                            j = str.Length - 1;
                        }
                    }

                    if (contains == true)
                    {
                        result[key]++;
                    }
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}

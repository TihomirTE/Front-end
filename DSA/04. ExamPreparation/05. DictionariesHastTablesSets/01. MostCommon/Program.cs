using System;
using System.Collections.Generic;

namespace _01.MostCommon
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var firstName = new Dictionary<string, int>();
            var lastName = new Dictionary<string, int>();
            var yearOfBirth = new Dictionary<string, int>();
            var eyeColor = new Dictionary<string, int>();
            var hairColor = new Dictionary<string, int>();
            var height = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                AddElementToDictionary(line[0], firstName);
                AddElementToDictionary(line[1], lastName);
                AddElementToDictionary(line[2], yearOfBirth);
                AddElementToDictionary(line[3], eyeColor);
                AddElementToDictionary(line[4], hairColor);
                AddElementToDictionary(line[5], height);
            }

            Console.WriteLine(FindElement(firstName));
            Console.WriteLine(FindElement(lastName));
            Console.WriteLine(FindElement(yearOfBirth));
            Console.WriteLine(FindElement(eyeColor));
            Console.WriteLine(FindElement(hairColor));
            Console.WriteLine(FindElement(height));
        }

        private static void AddElementToDictionary(string key, Dictionary<string, int> dictionary)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, 1);
            }
            else
            {
                dictionary[key]++;
            }

        }

        private static string FindElement(Dictionary<string, int> dictionary)
        {
            string result = "";
            int max = 0;

            foreach (var element in dictionary)
            {
                if (element.Value > max)
                {
                    result = element.Key;
                    max = element.Value;
                }

                if (element.Value == max)
                {
                    if (element.Key.CompareTo(result) < 0)
                    {
                        result = element.Key;
                    }
                }
            }

            return result;
        }
    }
}

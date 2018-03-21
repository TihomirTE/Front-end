using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.GirlsGoneWild
{
    public class Program
    {
        private static SortedSet<string> result = new SortedSet<string>();

        private static int numberOfPeople;

        private static List<List<int>> combOfNumbers = new List<List<int>>();
        private static List<List<char>> combOfLetters = new List<List<char>>();

        public static void Main()
        {
            // it is used for swap
            var numbers = new int[int.Parse(Console.ReadLine())];

            var letters = Console.ReadLine().ToCharArray().OrderBy(c => c).ToArray(); // sort lexicographical
            numberOfPeople = int.Parse(Console.ReadLine());

            Comb(numbers, 0, 0, comb =>
            {
                combOfNumbers.Add(new List<int>(comb));
            });

            numbers = new int[letters.Length];
            Comb(numbers, 0, 0, comb =>
            {
                var currentLetterComb = new List<char>();

                for (int i = 0; i < numberOfPeople; i++)
                {
                    currentLetterComb.Add(letters[comb[i]]);
                }

                combOfLetters.Add(currentLetterComb);
            });

            foreach (var numberComb in combOfNumbers)
            {
                foreach (var letterComb in combOfLetters)
                {
                    var newLetters = new List<char>(letterComb);
                    PermuteWithRep(newLetters, 0, newLetters.Count, perm =>
                    {
                        Merge(perm, numberComb);
                    });
                }
            }

            var stringResult = new StringBuilder();
            stringResult.AppendLine(result.Count.ToString());
            foreach (var item in result)
            {
                stringResult.AppendLine(item);
            }

            Console.WriteLine(stringResult.ToString().Trim());
        }

        private static void Merge(List<char> letters, List<int> numbers)
        {
            var stringBiulder = new StringBuilder();

            for (int i = 0; i < letters.Count; i++)
            {
                stringBiulder.Append(numbers[i]);
                stringBiulder.Append(letters[i]);
                stringBiulder.Append('-');
            }

            result.Add(stringBiulder.ToString().Trim('-'));
        }

        private static void PermuteWithRep(List<char> arr, int start, int n, Action<List<char>> action)
        {
            action(arr);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                    if (arr[left] != arr[right])
                    {
                        var oldValue = arr[left];
                        arr[left] = arr[right];
                        arr[right] = oldValue;

                        PermuteWithRep(arr, left + 1, n, action);
                    }
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                    arr[i] = arr[i + 1];
                arr[n - 1] = firstElement;
            }
        }

        // Combination on the numbers without repetition
        private static void Comb(int[] arr, int index, int start, Action<int[]> action)
        {
            if (index >= numberOfPeople)
            {
                action(arr);
            }
            else
                for (int i = start; i < arr.Length; i++)
                {
                    arr[index] = i;
                    Comb(arr, index + 1, i + 1, action);
                }
        }
    }
}

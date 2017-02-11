using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_IndexOfLetters
{
    class IndexOfLetters
    {
        static void Main()
        {
            string word = Console.ReadLine();
            char[] letters = word.ToCharArray();
            foreach (var letter in letters)
            {
                Console.WriteLine(letter - 97);
            }
        }
    }
}

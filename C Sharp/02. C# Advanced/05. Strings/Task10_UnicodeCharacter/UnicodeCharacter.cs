using System;
using System.Text;

namespace Task10_UnicodeCharacter
{
    class UnicodeCharacter
    {
        static void Main()
        {
            string text = Console.ReadLine();
            StringBuilder hex = new StringBuilder();
            foreach (char letter in text)
            {
                hex.AppendFormat("\\u{0:X4}", (int)letter);
            }
            Console.WriteLine(hex);
        }
    }
}

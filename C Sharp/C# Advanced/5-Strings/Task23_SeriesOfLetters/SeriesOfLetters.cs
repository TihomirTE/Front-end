using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task23_SeriesOfLetters
{
    class SeriesOfLetters
    {
        static void Main()
        {
            string text = Console.ReadLine();
            StringBuilder newText = new StringBuilder();

            for (int i = 0; i < text.Length - 1; i++)
            {
                newText.Append(text[i]);
                while (text[i] == text[i + 1])
                {
                    if (i < text.Length - 2)
                    {
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (text[text.Length - 2] != text[text.Length - 1])
            {
                newText.Append(text[text.Length - 1]);
            }
            Console.WriteLine(newText);
        }
    }
}

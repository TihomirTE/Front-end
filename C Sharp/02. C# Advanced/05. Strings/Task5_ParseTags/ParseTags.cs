using System;

namespace Task5_ParseTags
{
    class ParseTags
    {
        static void Main()
        {
            string text = Console.ReadLine();
            int indexStart = text.IndexOf("<upcase>");
            int indexEnd = text.IndexOf("</upcase>");

            while (indexStart != -1 && indexEnd != -1)
            {
                
                int lenghtOfText = indexEnd - indexStart + 9;
                string letters = text.Substring(indexStart, lenghtOfText);
                text = text.Replace(letters, letters.ToUpper());
                // Remove the <upcase>
                text = text.Remove(indexStart, 8);
                // Remove the </upcase>
                text = text.Remove((indexEnd - 8), 9);
                indexStart = text.IndexOf("<upcase>", indexStart + 1);
                if (indexStart == -1)
                {
                    continue;
                }
                indexEnd = text.IndexOf("</upcase>", indexEnd + 1);
                if (indexEnd == -1)
                {
                    continue;
                }
            }
            Console.WriteLine(text);
        }
    }
}

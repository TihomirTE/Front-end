using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task15_ReplaceTags
{
    class ReaplaceTags
    {
        static void Main()
        {
            string text = Console.ReadLine();
            int indexLinkStart = text.IndexOf("<a href=");
            StringBuilder format = new StringBuilder();
            format.Append(text, 0, indexLinkStart);
            while (indexLinkStart != -1)
            {
                int indexLinkEnd = text.IndexOf(">", indexLinkStart + 1);
                int indexInfoStart = indexLinkEnd + 1;
                int indexInfoEnd = text.IndexOf("</a>", indexInfoStart + 1);
                format.Append("[");
                format.Append(text, indexInfoStart, indexInfoEnd - indexInfoStart);
                format.Append("]");
                format.Append("(");
                format.Append(text, indexLinkStart + 9, indexLinkEnd - (indexLinkStart + 10));
                format.Append(")");
                indexLinkStart = text.IndexOf("<a href=", indexLinkStart + 1);
                if (indexLinkStart != -1)
                {
                    format.Append(text, indexInfoEnd + 4, (indexLinkStart - (indexInfoEnd + 4)));
                }
                else
                {
                    int indexEnd = text.IndexOf("</p>", 1);
                    format.Append(text, indexInfoEnd + 4, (indexEnd - indexInfoEnd));
                }
            }
            Console.WriteLine(format);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_HiddenMessage
{
    class HiddenMessage
    {
        static void Main()
        {
            var listText = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "")
                    continue;
                else if (input == "end")
                    break;
                else
                {
                    int posNum = int.Parse(input);
                    int step = int.Parse(Console.ReadLine());
                    var text = Console.ReadLine().ToArray();
                    int counter = 0;
                    int pos = 0;
                    while (pos < text.Length)
                    {
                        if (posNum < 0 && counter == 0)
                        {
                            pos = text.Length + posNum;
                            listText.Add(Convert.ToString(text[pos]));
                        }
                        else if (counter == 0)
                        {
                            pos = posNum;
                            if (pos >= text.Length)
                                break;
                            else
                                listText.Add(Convert.ToString(text[pos]));
                        }
                        else
                        {
                            pos = pos + step;
                            if (pos < text.Length && pos >= 0)
                                listText.Add(Convert.ToString(text[pos]));
                            else
                                break;
                        }
                        counter++;
                    }
                }
            }
            for (int i = 0; i < listText.Count; i++)
            {
                Console.Write(listText[i]);
            }
            Console.WriteLine();
        }
    }
}

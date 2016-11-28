using System;
using System.Text;

namespace Task6_StringLenght
{
    class StringLenght
    {
        static void Main()
        {
            string text = Console.ReadLine();
            if (text.Length == 20)
            {
                Console.WriteLine(text);
            }
            else
            {
                StringBuilder addedText = new StringBuilder();
                for (int i = text.Length; i < 20; i++)
                {
                    addedText.Append("*");
                }
                Console.WriteLine(text + addedText);
            }
        }
    }
}

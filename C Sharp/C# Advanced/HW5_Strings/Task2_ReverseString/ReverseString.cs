using System;

namespace Task2_ReverseString
{
    class ReverseString
    {
        static void Main()
        {
            string str = Console.ReadLine();
            string reversedStr = "";

            for (int i = str.Length - 1; i >= 0; i--)
            {
                reversedStr += str[i];
            }
            Console.WriteLine(reversedStr);
        }
    }
}

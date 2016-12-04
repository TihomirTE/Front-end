using System;

namespace Task3_CorrectBrackets
{
    class CorrectBrackets
    {
        static void Main(string[] args)
        {
        string text = Console.ReadLine();
        string result = CounterBrackets(text);
        Console.WriteLine(result);
        }
    static string CounterBrackets(string str)
    {
        int counter = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '(')
            {
                counter++;
            }
            else if (str[i] == ')')
            {
                counter--;
            }
        }
        if (counter == 0)
        {
            return "Correct";
        }
        else
        {
            return "Incorrect";
        }
    }
}
}

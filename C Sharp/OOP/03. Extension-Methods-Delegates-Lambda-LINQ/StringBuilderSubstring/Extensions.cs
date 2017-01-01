namespace StringBuilderSubstring
{
    using System;
    using System.Text;

    /* Problem 1. StringBuilder.Substring
    Implement an extension method Substring(int index, int length)
    for the class StringBuilder that returns new StringBuilder and
    has the same functionality as Substring in the class String.*/

    public static class Extensions
    {
        public static StringBuilder SubString(this StringBuilder input, int start, int lenght)
        {
            // in case the index is out of range
            if (start < 0 || start >= input.Length || start + lenght > input.Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                StringBuilder result = new StringBuilder();

                for (int i = start; i < start + lenght; i++)
                {
                    result.Append(input[i]);
                }
                return result;
            }
        }
    }
}

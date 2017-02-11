using System;


namespace Task4_SubstringInText
{
    class SubstringInText
    {
        static void Main()
        {
            string pattern = Console.ReadLine().ToLower();
            string text = Console.ReadLine().ToLower();

            int index = text.IndexOf(pattern);
            int counter = 1;
            while (index != -1)
            {
                index = text.IndexOf(pattern, index + 1);
                if (index == -1)
                {
                    break;
                }
                counter++;
            }
            Console.WriteLine(counter);
        }
    }
}

using System;

namespace _04.Documentation
{
    public class Doc
    {
        public static void Main()
        {
            string input = Console.ReadLine().ToLower();
            int len = input.Length;
            int result = 0;

            for (int i = 0, j = len - 1; i < j; i++, j--)
            {
                char start = input[i];
                char end = input[j];

                if (start < 97 || start > 122)
                {
                    if (end < 97 || end > 122)
                    {
                        continue;
                    }

                    j++;
                    continue;
                }

                if (end < 97 || end > 122)
                {
                    i--;
                    continue;
                }

                if (start == end)
                {
                    continue;
                }

                int upperCounter = 0;
                var temp = end;

                while (start != temp)
                {
                    temp++;
                    upperCounter++;
                    if (temp == 123)
                    {
                        temp = 'a';
                    }
                }

                temp = end;
                int downCounter = 0;

                while (start != temp)
                {
                    temp--;
                    downCounter++;
                    if (temp == 96)
                    {
                        temp = 'z';
                    }
                }

                result += Math.Min(upperCounter, downCounter);
            }

            Console.WriteLine(result);
        }
    }
}

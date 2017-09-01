using System;
using System.Collections.Generic;

namespace _03.TheRings
{
    public class Rings
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var input = new List<int>();
            var listResult = new List<int>();
            int counter = 1;
            int result = 1;

            for (int i = 0; i < n; i++)
            {
                input.Add(int.Parse(Console.ReadLine()));
            }

            input.Sort();

            for (int i = 1; i < n; i++)
            {
                if (input[i - 1] == input[i])
                {
                    counter += 1;
                    listResult.Add(counter);
                }
                else
                {
                    counter = 1;
                }
            }

            for (int i = 0; i < listResult.Count; i++)
            {
                result *= listResult[i];
            }

            Console.WriteLine(result);
        }
    }
}
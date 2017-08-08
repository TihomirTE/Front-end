using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Goro
{
    public class Goro
    {
        public static void Main()
        {
            var list = new List<int>();
            int num1 = int.Parse(Console.ReadLine());
            list.Add(num1);
            int num2 = int.Parse(Console.ReadLine());
            list.Add(num2);
            int num3 = int.Parse(Console.ReadLine());
            list.Add(num3);

            int n = int.Parse(Console.ReadLine());
            int points = 0;
            int maxValue = 0;
            int index = 0;

            for (int i = 0; i < n; i++)
            {
                maxValue = list.Max();
                points += maxValue;
                index = list.IndexOf(maxValue);
                maxValue = list[index];
                if (maxValue >= 1)
                {
                    maxValue--;
                    list[index] = maxValue;
                }
            }

            Console.WriteLine(points);
        }
    }
}

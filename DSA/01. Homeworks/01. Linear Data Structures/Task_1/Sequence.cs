using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_01
{
    public class Sequence
    {
        public static void Main()
        {
            var list = new List<int>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == string.Empty)
                {
                    break;
                }

                var num = int.Parse(input);

                if (num > 0)
                {
                    list.Add(num);
                }
            }

            var sum = list.Sum();
            var average = list.Average();

            Console.WriteLine(sum);
            Console.WriteLine("{0:0.00}", average);
        }
    }
}

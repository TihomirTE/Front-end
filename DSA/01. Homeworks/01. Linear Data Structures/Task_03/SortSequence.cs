using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_03
{
    public class SortSequence
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
                list.Add(num);
            }

            var sorted = list.OrderBy(x => x);
            Console.WriteLine(string.Join(", ", sorted));
        }
    }
}

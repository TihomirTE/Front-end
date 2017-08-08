using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Anagrami
{
    public class Anagrami
    {
        public static void Main()
        {
            string input;
            string group = " ";
            var list = new List<string>();
            int numberOfGroups = 0;

            do
            {
                input = Console.ReadLine();

                // Sort Alphabetically
                group = String.Concat(input.OrderBy(c => c));

                if (group != "-1" && list.IndexOf(group) == -1)
                {
                    list.Add(group);

                    numberOfGroups++;
                }

            } while (input != "-1");

            Console.WriteLine(numberOfGroups);
        }
    }
}

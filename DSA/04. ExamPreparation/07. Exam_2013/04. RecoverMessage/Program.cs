using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RecoverMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string line;
            var set = new HashSet<char>();
            var resultSet = new HashSet<char>();

            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine();
                foreach (var ch in line)
                {
                    set.Add(ch);
                }
            }

            foreach (var item in set)
            {
                if (item >= 65 && item <= 90)
                {
                    resultSet.Add(item);
                }
            }

            foreach (var item in set)
            {
                if (item >= 97 && item <= 122)
                {
                    resultSet.Add(item);
                }
            }

            var result = new StringBuilder();

            foreach (var item in resultSet)
            {
                result.Append(item);
            }
            Console.WriteLine(result.ToString());
        }
    }
}

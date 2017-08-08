using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Lazyness
{
    public class Lazyness
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var indexes = Console.ReadLine().Split(' ').Select(item => int.Parse(item)).ToArray();
            var numbers = Console.ReadLine().Split(' ').Select(item => int.Parse(item)).ToList();
            int start = indexes[0];
            int end = indexes[1];
            int len = end - start + 1;

            var sortedArr = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i >= start && i <= end)
                {
                    sortedArr.Add(numbers[i]);
                }
            }

            numbers.RemoveRange(start, len);

            sortedArr.Sort();
            numbers.InsertRange(start, sortedArr);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

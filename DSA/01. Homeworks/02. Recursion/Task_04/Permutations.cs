using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04
{
    public class Permutations
    {
        private static Stack<int> stack = new Stack<int>();

        public static void Main()
        {
            int n = 3;
            CalculatePermutations(n);
        }

        private static void CalculatePermutations(int n)
        {
            if (stack.Count == n)
            {
                Console.WriteLine(string.Join(", ", stack));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (!stack.Contains(i))
                {
                    stack.Push(i);
                    CalculatePermutations(n);
                    stack.Pop();
                }
            }
        }
    }
}

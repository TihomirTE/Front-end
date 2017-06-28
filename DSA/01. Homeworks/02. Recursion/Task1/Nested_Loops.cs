using System;
using System.Collections.Generic;

namespace Task_01
{
    public class Nested_Loops
    {
        private static Stack<int> stack = new Stack<int>();

        public static void Main(string[] args)
        {
            int n = 3;
            NestedLoops(n);
        }

        private static void NestedLoops(int n)
        {
            if (stack.Count == n)
            {
                Console.WriteLine(string.Join(", ", stack));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                stack.Push(i);
                NestedLoops(n);
                stack.Pop();
            }
        }
    }
}

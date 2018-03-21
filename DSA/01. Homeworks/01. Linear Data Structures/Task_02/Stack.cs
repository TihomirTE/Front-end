using System;
using System.Collections.Generic;

namespace Task_02
{
    public class Stack
    {
        public static void Main()
        {
            var stack = new Stack<int>();

            var num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                var number = int.Parse(Console.ReadLine());

                stack.Push(number);
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}

using System;
using Task12_Stack.Stack;

namespace Task12_Stack
{
    public class Startup
    {
        public static void Main()
        {
            var customStack = new CustomStack<int>();

            for (int i = 0; i < 5; i++)
            {
                customStack.Push(i);
            }

            Console.WriteLine(customStack.Peek());
            Console.WriteLine(customStack.Count);

            while (customStack.Count > 0)
            {
                Console.Write($"{customStack.Pop()} ");
            }
            Console.WriteLine();
        }
    }
}

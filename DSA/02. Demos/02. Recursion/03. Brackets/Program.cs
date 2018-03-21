using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Brackets
{
    public class Program
    {
        public static void Main()
        {
            var str = "1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5";
            var stack = new Stack<int>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    stack.Push(i);
                }
                else if (str[i] == ')')
                {
                    var start = stack.Peek();
                    var length = i + 1 - start;

                    Console.WriteLine(str.Substring(start, length));
                    stack.Pop();
                }
            }
        }
    }
}

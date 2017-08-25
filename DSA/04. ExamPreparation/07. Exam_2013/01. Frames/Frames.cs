using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Frames
{
    class Frames
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            var frames = new List<Frame>();

            for (int i = 0; i < rows; i++)
            {
                var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                frames.Add(new _01.Frames.Frames.Frame(sizes[0], sizes[1]));
            }

        }

        struct Frame
        {
            public Frame(int a, int b)
            {
                A = a;
                B = b;
            }

            public int A { get; set; }
            public int B { get; set; }
        }
    }
}

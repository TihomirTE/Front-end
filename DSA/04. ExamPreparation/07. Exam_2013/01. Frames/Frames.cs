using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Frames
{
    class Frames
    {
        static SortedSet<string> sortedSet = new SortedSet<string>();

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            var frames = new Frame[rows];

            for (int i = 0; i < rows; i++)
            {
                var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                frames[i] = (new Frame(sizes[0], sizes[1]));
            }

            Perm(frames, 0);

            Console.WriteLine(sortedSet.Count);
            var output = new StringBuilder();
            foreach (var item in sortedSet)
            {
                output.AppendLine(item);
            }

            Console.WriteLine(output.ToString().Trim());
        }

        static void Perm(Frame[] arr, int k)
        {
            if (k >= arr.Length)
            {
                sortedSet.Add(string.Join(" | ", arr));

            }
            else
            {
                Perm(arr, k + 1);
                SwapFrame(ref arr[k]);
                Perm(arr, k + 1);
                SwapFrame(ref arr[k]);

                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);

                    Perm(arr, k + 1);
                    SwapFrame(ref arr[k]);
                    Perm(arr, k + 1);
                    SwapFrame(ref arr[k]);

                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void SwapFrame(ref Frame frame)
        {
            int oldFirst = frame.A;
            frame.A = frame.B;
            frame.B = oldFirst;
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
        
        struct Frame
        {
            public Frame(int a, int b) : 
                this()
            {
                this.A = a;
                this.B = b;
            }

            public int A { get; set; }
            public int B { get; set; }

            public override string ToString()
            {
                return string.Format("({0}, {1})", this.A, this.B);
            }
        }
    }
}

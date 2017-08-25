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
                frames.Add(new Frame(sizes[0], sizes[1]));
            }

        }

        static void Perm<T>(T[] arr, int k)
        {
            if (k >= arr.Length)
            {

            }
            else
            {
                Perm(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    Perm(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
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

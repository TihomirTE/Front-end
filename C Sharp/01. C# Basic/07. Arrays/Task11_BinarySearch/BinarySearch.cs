using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11_BinarySearch
{
    class BinarySearch
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int[] array = new int[num];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            int x = int.Parse(Console.ReadLine());

            int pos = 0;
            int first = 0;
            int last = array.Length - 1;
            bool match = false;
            // sorted array with ascening values
            while (first <= last)
            {
                pos = (first + last) / 2;
                if (x < array[pos])
                {
                    last = pos - 1;
                }
                else if (x > array[pos])
                {
                    first = pos + 1;
                }
                else if (x == array[pos])
                {
                    match = true;
                    break;
                }
            }
            if (match == true)
            {
                Console.WriteLine(pos);
            }
            else
            {
                Console.WriteLine(-1);
            }
        }
    }
}

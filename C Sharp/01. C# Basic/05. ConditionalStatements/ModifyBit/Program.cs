using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifyBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int p;
            ulong n;
            uint v;
            ulong one = 1;
            n = Convert.ToUInt64(Console.ReadLine());
            p = Convert.ToInt32(Console.ReadLine());
            v = Convert.ToUInt32(Console.ReadLine());
            if (p > 0)
            {
                n &= ~(one << p);
                n |= (v << p);
                Console.WriteLine(n);
            }
            else
            {
                n &= one;
                n |= (v << p);
                Console.WriteLine(n);
            }
        }
    }
}

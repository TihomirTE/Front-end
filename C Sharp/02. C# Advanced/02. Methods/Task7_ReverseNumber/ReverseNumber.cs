using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_ReverseNumber
{
    class ReverseNumber
    {
        static void Main()
        {
            string number = Console.ReadLine();
            ReverseDigits(number);
        }

        static void ReverseDigits(string num)
        {
            var reversed = num.Reverse().ToArray();
            Console.WriteLine(reversed);
        }
    }
}

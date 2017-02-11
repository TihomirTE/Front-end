using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_EnglishDigit
{
    class EnglishDigit
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            string lastDigit = LastDigit(number);
            Console.WriteLine(lastDigit);
        }

        static string LastDigit(int number)
        {
            int last = number % 10;
            switch (last)
            {
                case 1: return "one";
                case 2: return "two"; 
                case 3: return "three"; 
                case 4: return "four"; 
                case 5: return "five"; 
                case 6: return "six"; 
                case 7: return "seven"; 
                case 8: return "eight"; 
                case 9: return "nine"; 
                default:
                    return "zero";
            }
        }
    }
}

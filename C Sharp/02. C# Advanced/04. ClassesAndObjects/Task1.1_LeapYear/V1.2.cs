using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._1_LeapYear
{
    class Program
    {
        static void Main()
        {
            /*if (year is not divisible by 4) then (it is a common year)
              else if (year is not divisible by 100) then (it is a leap year)
              else if (year is not divisible by 400) then (it is a common year)
              else (it is a leap year)*/
            int year = int.Parse(Console.ReadLine());
            string leapYear = "";

            if (year % 4 != 0)
            {
                leapYear = "Common";
            }
            else if (year % 100 != 0)
            {
                leapYear = "Leap";
            }
            else if (year % 400 != 0)
            {
                leapYear = "Common";
            }
            else
            {
                leapYear = "Leap";
            }
            Console.WriteLine(leapYear);
        }
    }
}

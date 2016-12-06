using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_2015_SearchInBits
{
    class SearchInBits
    {
        static void Main()
        {
            int s = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int pattern = Convert.ToString(s, 2).Length;
            int occurrence = 0;
            int tempNumber = 0;
            int mask = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                
                for (int j = 30; j >= pattern; j--)
                {
                    mask = s << (30 - j);
                    tempNumber = (number & mask);
                    if (tempNumber == mask)
                    {
                        occurrence++;
                    }
                }
            }
            Console.WriteLine(occurrence);
        }
    }
}

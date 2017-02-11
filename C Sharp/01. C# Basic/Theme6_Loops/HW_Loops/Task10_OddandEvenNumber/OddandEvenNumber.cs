using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10_OddandEvenNumber
{
    class OddandEvenNumber
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Select(item => int.Parse(item)).ToArray();
            long sumOdd = 1;
            long sumEven = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if ((i + 1) % 2 == 1)
                {
                    sumOdd *= numbers[i];
                }
                else
                {
                    sumEven *= numbers[i];
                }
            }
            if (sumEven == sumOdd)
            {
                Console.WriteLine("yes {0}", sumOdd);
            }
            else
            {
                Console.WriteLine("no {0} {1}", sumOdd, sumEven);
            }
        }                 
    }
}

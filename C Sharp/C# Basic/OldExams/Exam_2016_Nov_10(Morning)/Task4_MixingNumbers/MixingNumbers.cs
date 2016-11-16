using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_MixingNumbers
{
    class MixingNumbers
    {
        static void Main()
        {
            int numbers = int.Parse(Console.ReadLine());
            var firstLine = new int[numbers - 1];
            var secondLine = new int[numbers - 1];

            int firstNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbers - 1; i++)
            {
                int secondNum = int.Parse(Console.ReadLine());
                int b = firstNum % 10;
                int c = (secondNum / 10) % 10;
                firstLine[i] = b * c;
                int diff = firstNum - secondNum;
                secondLine[i] = Math.Abs(diff);
                firstNum = secondNum;
            }
            Console.WriteLine(String.Join(" ", firstLine));
            Console.WriteLine(String.Join(" ", secondLine));
        }
    }
}

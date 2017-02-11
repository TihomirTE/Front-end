using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Таск4_SequenceOfBits
{
    class SequenceBits
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            var binaryNumber = new List<string>();
            for (int j = 0; j < num; j++)
            {
                int number = int.Parse(Console.ReadLine());

                var currentNum = new string[30];
                int i = 29;

                while (i >= 0)
                {
                    if ((number & (1 << i)) != 0)
                    {
                        binaryNumber.Add("1");
                    }
                    else
                    {
                        binaryNumber.Add("0");
                    }
                    i--;
                }
            }
            int counterOnes = 0;
            int counterZeros = 0;
            int sequenseOnes = 0;
            int sequenceZeros = 0;
            for (int i = 0; i < binaryNumber.Count; i++)
            {
                if (binaryNumber[i] == "1")
                {
                    counterOnes++;
                    if (counterOnes > sequenseOnes)
                    {
                        sequenseOnes = counterOnes;
                    }
                    counterZeros = 0;
                }
                else
                {
                    counterZeros++;
                    if (counterZeros > sequenceZeros)
                    {
                        sequenceZeros = counterZeros;
                    }
                    counterOnes = 0;
                }
            }
            Console.WriteLine(sequenseOnes);
            Console.WriteLine(sequenceZeros);
        }
    }
}

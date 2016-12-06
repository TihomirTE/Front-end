using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task5_BitsToBits
{
    class BitsToBits
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sequence = new StringBuilder();
            string numberString = string.Empty;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numberString = Convert.ToString(number, 2).PadLeft(30, '0');
                sequence.Append(numberString);
            }

            int counterZeros = 0;
            int counterOnes = 0;
            int bestCounterZeros = 0;
            int bestCounterOnes = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == '0')
                {
                    counterZeros++;
                    counterOnes = 0;
                }
                if (sequence[i] == '1')
                {
                    counterOnes++;
                    counterZeros = 0;
                }
                if (counterZeros > bestCounterZeros)
                {
                    bestCounterZeros = counterZeros;
                }
                if (counterOnes > bestCounterOnes)
                {
                    bestCounterOnes = counterOnes;
                }
            }

            Console.WriteLine(bestCounterZeros);
            Console.WriteLine(bestCounterOnes);




            /*var n = int.Parse(Console.ReadLine());
            var numbersSequence = new long[n * 30];
            var remainNumber = 0;
            //var index = 0;
            var sequenceOfZero = 0;
            var maxSequenceOfZero = 0;
            var sequenceOfOne = 0;
            var maxSequenceOfOne = 0;

            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());
                for (int seq = 0; seq < 30; seq++)
                {
                    remainNumber = number % 2;
                    if (remainNumber == 1)
                    {
                        sequenceOfOne++;
                        sequenceOfZero = 0;
                    }

                    else
                    {
                        sequenceOfZero++;
                        sequenceOfOne = 0;
                    }
                    if (sequenceOfOne > maxSequenceOfOne)
                    {
                        maxSequenceOfOne = sequenceOfOne;
                    }
                    if (sequenceOfZero > maxSequenceOfZero)
                    {
                        maxSequenceOfZero = sequenceOfZero;
                    }
                    number /= 2;
                    //numbersSequence[index] = remainNumber;
                    //index++;
                }
            }
            Console.WriteLine(maxSequenceOfZero);
            Console.WriteLine(maxSequenceOfOne);



            /*var sequenceOfZero = 0;
            var maxSequenceOfZero = -1;
            var sequenceOfOne = 0;
            var maxSequenceOfOne = -1;
            for (int i = 0; i < numbersSequence.Length; i++)
            {
                while (numbersSequence[i] == 0 && i < numbersSequence.Length)
                {
                    sequenceOfZero++;
                    i++;
                }
                while (numbersSequence[i] == 1 && i < numbersSequence.Length)
                {
                    sequenceOfOne++;
                    i++;
                }
                if (sequenceOfZero > maxSequenceOfZero)
                {
                    maxSequenceOfZero = sequenceOfZero;
                }
                sequenceOfZero = 0;
                if (sequenceOfOne > maxSequenceOfOne)
                {
                    maxSequenceOfOne = sequenceOfOne;
                }
                sequenceOfOne = 0;
            }*/


        }
    }
}

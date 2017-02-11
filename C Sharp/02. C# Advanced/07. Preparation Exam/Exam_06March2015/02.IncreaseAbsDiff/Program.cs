using System;
using System.Linq;

namespace _02.IncreaseAbsDiff
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var result = new string[num];
            for (int i = 0; i < num; i++)
            {
                var seq = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var seqAbsDiff = new int[seq.Length - 1];
                seqAbsDiff = FindAbsDiff(seq);
                result[i] = FindIncreasingSeq(seqAbsDiff);
            }
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(result[i]);
            }
        }

        private static string FindIncreasingSeq(int[] seqAbsDiff)
        {
            bool increaseSeq = true;
            string result = string.Empty;
            for (int i = 0; i < seqAbsDiff.Length - 1; i++)
            {
                if ((seqAbsDiff[i + 1] - seqAbsDiff[i] > 1) 
                    || seqAbsDiff[i] > seqAbsDiff[i + 1])
                {
                    result = "False";
                    increaseSeq = false;
                    break;
                }
            }
            if (increaseSeq == true)
            {
                result = "True";
            }
            return result;
        }

        private static int[] FindAbsDiff(int[] seq)
        {
            int bigger = 0;
            int smaller = 0;
            int[] absDiff = new int[seq.Length - 1];
            for (int i = 0; i < seq.Length - 1; i++)
            {
                if (seq[i] > seq[i + 1])
                {
                    bigger = seq[i];
                    smaller = seq[i + 1];
                }
                else
                {
                    bigger = seq[i + 1];
                    smaller = seq[i];
                }
                absDiff[i] = bigger - smaller;
            }
            return absDiff;
        }
    }
}

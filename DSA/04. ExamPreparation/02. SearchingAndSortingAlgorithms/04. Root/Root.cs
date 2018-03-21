using System;
using System.Numerics;

namespace _04.Root
{
    public class Root
    {
        public static void Main()
        {
            BigInteger num = BigInteger.Parse(Console.ReadLine());
            BigInteger lowBorder = 0;
            BigInteger highBorder = num;
            BigInteger currentRoot = highBorder / 2;


            BigInteger power3 = currentRoot * currentRoot * currentRoot;

            while (power3 != num)
            {
                if (power3 > num)
                {
                    highBorder = currentRoot;
                    currentRoot = highBorder / 2;
                }
                else
                {
                    lowBorder = currentRoot;
                    currentRoot = (lowBorder + highBorder) / 2;
                }

                power3 = currentRoot * currentRoot * currentRoot;
            }

            Console.WriteLine(currentRoot);
        }
    }
}

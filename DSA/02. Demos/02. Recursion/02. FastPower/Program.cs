using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.FastPower
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(FastPower(7, 10));
        }

        private static BigInteger FastPower(int number, int power)
        {
            if (power == 0)
            {
                return 1;
            }

            if (power % 2 == 0)
            {
                return number * FastPower(number, power - 1);
            }

            BigInteger halfPower = FastPower(number, power / 2);
            return halfPower * halfPower;
        }
    }
}

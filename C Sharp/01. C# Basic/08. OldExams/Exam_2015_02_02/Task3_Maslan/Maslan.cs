using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task3_Maslan
{
    class Maslan
    {
        static void Main()
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            int counter = 0;

            while (number.ToString().Length > 1)
            {
                BigInteger sum = 1;
                while (number > 0)
                {
                    number /= 10;
                    BigInteger currentSum = 0;
                    string magicNum = number.ToString();
                    for (int i = 0; i < magicNum.Length; i++)
                    {
                        if (i % 2 == 1)
                        {
                            currentSum += Convert.ToInt32(magicNum[i] - '0');
                        }
                    }
                    if (currentSum != 0)
                    {
                        sum *= currentSum;
                    }
                }
                number = sum;
                counter++;
                if (counter == 10)
                {
                    break;
                }
            }
            if (counter == 10)
            {
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine(counter);
                Console.WriteLine(number);
            }

        }
    }
}

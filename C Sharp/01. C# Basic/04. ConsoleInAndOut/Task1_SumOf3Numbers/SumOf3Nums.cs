using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_SumOf3Numbers
{
    class SumOf3Nums
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());

            double sum = num1 + num2 + num3;
            Console.WriteLine(sum);
        }
    }
}

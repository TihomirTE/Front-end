using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11_Adding_polynomials
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            var polynom1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var polynom2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            SumPolynoms(polynom1, polynom2, num);
        }

        static void SumPolynoms(int[] polynom1, int[] polynom2, int num)
        {
            var sumPolynom = new int[num];
            for (int i = 0; i < num; i++)
            {
                sumPolynom[i] = polynom1[i] + polynom2[i];
            }
            for (int i = 0; i < num; i++)
            {
                Console.Write(sumPolynom[i] + " ");
            }
            Console.WriteLine();
        }
    }
}

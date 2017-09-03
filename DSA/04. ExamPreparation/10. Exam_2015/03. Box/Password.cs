using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Password
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var relations = Console.ReadLine();
            var k = int.Parse(Console.ReadLine());

            var digits = new int[n];
            var result = new char[n];

            FindResult(0, n, k, digits, relations, result);

            Console.WriteLine(result);
        }

        private static int FindResult(int index, int n, int k, int[] digits, string relations, char[] result)
        {
            if (k <= 0)
            {
                return k;
            }

            if (index == n)
            {
                k--;
                if (k == 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        result[i] = (char)(digits[i] + '0');
                    }
                }

                return k;
            }

            if (index == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    digits[0] = i;
                    k = FindResult(index + 1, n, k, digits, relations, result);
                }

                return k;
            }

            if (relations[index - 1] == '<')
            {
                int digit = digits[index - 1] == 0 ? 10 : digits[index - 1];
                for (int i = 1; i < digit; i++)
                {
                    digits[index] = i;
                    k = FindResult(index + 1, n, k, digits, relations, result);
                }
            }

            if (relations[index - 1] == '>')
            {
                int digit = digits[index - 1];
                if (digit == 0)
                {
                    return k;
                }

                digits[index] = 0;
                k = FindResult(index + 1, n, k, digits, relations, result);

                for (int i = digit + 1; i < 10; i++)
                {
                    digits[index] = i;
                    k = FindResult(index + 1, n, k, digits, relations, result);
                }

                return k;
            }

            digits[index] = digits[index - 1];
            return FindResult(index + 1, n, k, digits, relations, result);
        }
    }
}

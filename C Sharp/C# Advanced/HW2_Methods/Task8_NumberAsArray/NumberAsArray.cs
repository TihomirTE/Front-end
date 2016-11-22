using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Task8_NumberAsArray
{
    class NumberAsArray
    {
        static void Main()
        {
            // var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var nums = Console.ReadLine();
            var arr1 = Console.ReadLine().Split(' ').ToString();
            var arr2 = Console.ReadLine().Split(' ').ToString();
            BigInteger num1 = ConvertArrayToNumber(arr1);
            BigInteger num2 = ConvertArrayToNumber(arr2);
            SumNumbers(num1, num2);
        }
        static BigInteger ConvertArrayToNumber(string arr)
        {
            var reversedNum1 = arr.Reverse().ToString();
            BigInteger number = BigInteger.Parse(reversedNum1);
            return number;
        }
        static void SumNumbers(BigInteger number1, BigInteger number2)
        {
            BigInteger sum = number1 + number2;
            var reversedSum = sum.ToString().Reverse();
            Console.WriteLine(reversedSum);      
        }
    }
}

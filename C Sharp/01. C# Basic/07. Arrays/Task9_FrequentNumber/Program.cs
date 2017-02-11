using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9_FrequentNumber
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            arr = arr.OrderByDescending(c => c).ToArray();
            int counter = 1;
            int currentCounter = 0;
            int number = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                while (arr[i] == arr[i + 1])
                {
                    counter++;
                    if (counter > currentCounter)
                    {
                        currentCounter = counter;
                        number = arr[i];
                    }
                    i++;
                    if (i == arr.Length - 1)
                    {
                        break;
                    }
                }
                counter = 1;
            }
            Console.WriteLine("{0} ({1} times)", number, currentCounter);
        }
    }
}

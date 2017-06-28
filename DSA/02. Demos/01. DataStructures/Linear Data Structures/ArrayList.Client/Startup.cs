using ArrayList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList.Client
{
    class Program
    {
        public static void Main()
        {
            var numbers = new CustomArrayList();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            Console.WriteLine(numbers.Contains(5));
            Console.WriteLine(numbers.IndexOf(3));

            numbers.Remove(4);
            numbers.RemoveAt(0);
            for (int i = 0; i < numbers.Count; i++)
            {
                // TODO implement indexator
                Console.WriteLine(numbers[i]);
            }
            //Console.WriteLine(string.Join(", ", numbers));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Money
{
    class Money
    {
        static void Main()
        {
            double students = double.Parse(Console.ReadLine());
            double papers= double.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());

            double totalNumberOfPages = students * papers;
            double numberOfRealm = totalNumberOfPages / 400;
            double money = numberOfRealm * price;
            Console.WriteLine("{0:f3}", money);
        }
    }
}

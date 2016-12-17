using System;
using System.Collections.Generic;

namespace _01.Defining_Classes_Part_1
{
    public class GSMTest
    {
        public static void Main()
        {
            var phoneCollection = new List<GSM>();

            var batteryHours = new Battery(150, 80);
            var screenSize = new Display(5.5);

            var samsung = new GSM ("Galaxy S7", "Samsung", 1000, screenSize);
            phoneCollection.Add(samsung);
            var nokia = new GSM("nokia3310", "Nokia");
            phoneCollection.Add(nokia);
            var lenovo = new GSM("Lenovo A7700", "Lenovo", "Somebody", 700, batteryHours);
            phoneCollection.Add(lenovo);

            for (int i = 0; i < phoneCollection.Count; i++)
            {
                Console.WriteLine(phoneCollection[i]);
            }

            Console.WriteLine(GSM.IPhone4S);
        }
    }
}

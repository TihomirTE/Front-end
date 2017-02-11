using System;


namespace Task9IntDoubleOrString
{
    class IntDoubleString
    {
        static void Main()
        {
            string type = Console.ReadLine();
            if (type == "integer")
            {
                int integer = int.Parse(Console.ReadLine());
                Console.WriteLine(integer + 1);
            }
            else if (type == "real")
            {
                double real = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:f2}", real + 1);
            }
            else
            {
                string str = Console.ReadLine();
                Console.WriteLine(str + "*");
            }
        }
    }
}

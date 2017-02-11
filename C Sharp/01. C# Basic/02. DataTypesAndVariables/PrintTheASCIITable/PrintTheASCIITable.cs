using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASCII_Table
{
    class ASCII_Table
    {
        static void Main()
        {
            for (int i = 33; i <= 126; i++)
            {
                char symbol = (char)i;
                Console.Write(symbol);
            }

        }
    }
}

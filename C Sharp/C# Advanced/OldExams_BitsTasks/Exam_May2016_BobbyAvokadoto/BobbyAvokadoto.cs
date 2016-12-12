using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_BobbyAvokadoto
{
    class Program
    {
        static void Main()
        {
            // http://bgcoder.com/Contests/Practice/Index/337#4

            uint head = uint.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            int bestCounter = 0;
            uint bestCumb = 0;
            for (int i = 0; i < number; i++)
            {
                // read the cumb
                uint cumb = uint.Parse(Console.ReadLine());

                // check the cumb
                if ((cumb & head) == 0)
                {
                    uint counter = 0;
                    uint currentCumb = cumb;
                    // check the suitable cumb
                    for (int j = 0; j < 32; j++)
                    {
                        counter += (currentCumb >> j) & 1;
                    }
                    // save the best cumb
                    if (counter > bestCounter)
                    {
                        bestCounter = (int)counter;
                        bestCumb = cumb;
                    }
                }
            }
            Console.WriteLine(bestCumb);
        }
    }
}

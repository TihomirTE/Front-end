using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_JumpJump
{
    class JumpJump
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var array = input.ToCharArray();

            int i = 0;
            while (true)
            {
                if ((array[i] - '0') % 2 == 1 && array[i] != '^')
                {
                    i -= array[i] - '0';
                }
                else if ((array[i] - '0') % 2 == 0 && (array[i] - '0') != 0 && array[i] != '^')
                {
                    i += array[i] - '0';
                }

                if (i < 0 || i >= array.Length)
                {
                    Console.WriteLine("Fell off the dancefloor at {0}!", i);
                    break;
                }
                else if (array[i] == '^')
                {
                    Console.WriteLine("Jump, Jump, DJ Tomekk kommt at {0}!", i);
                    break;
                }
                else if ((array[i] - '0') == 0)
                {
                    Console.WriteLine("Too drunk to go on after {0}!", i);
                    break;
                }
            }
        }
    }
}

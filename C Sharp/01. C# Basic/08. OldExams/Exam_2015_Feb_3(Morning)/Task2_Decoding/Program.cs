using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Decoding
{
    class Decoding
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            var array = text.ToCharArray();

            /*•	If the character is “@”, stop the program
              •	If the character in the original text is a letter, multiply its char code by the given SALT and add 1000.
              •	If the character in the original text is a digit, add to its char code SALT and add 500
              •	If the character in the original text is not a digit or letter (any other symbol), subtract from its char code SALT
              •	After performing the above operations on the character in the original text:
                 o	If the character is on even position in the original text - divide the encoded value by 100 and round the precision to 2 decimal digits right of the decimal point
                 o	Else if the character is on odd position in the original text - multiply by 100
                 o	The first character is at position 0.*/

            for (int i = 0; i < array.Length - 1; i++)
            {
                double result = 0;
                if ((array[i] >= 'A' && array[i] <= 'Z') || (array[i] >= 'a' && array[i] <= 'z'))
                {
                    result = (array[i] * number) + 1000;
                }
                else if (array[i] >= '0' && array[i] <= '9')
                {
                    result = array[i] + number + 500;
                }
                else
                {
                    result = array[i] - number;
                }
                if (i % 2 == 0)
                {
                    result /= 100;
                    Console.WriteLine("{0:f2}", result);
                }
                else
                {
                    result *= 100;
                    Console.WriteLine(result);
                }
            }
        }
    }
}

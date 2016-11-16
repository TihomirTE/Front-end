using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_EncodingSum
{
    class EncodingSum
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var text = Console.ReadLine().ToLower();
            var charArray = text.ToArray();
            
            int result = 0;

            /* -	If the current character is '@', stop the program and print the value of RESULT
               -    If the current character is a digit (‘0’ – ‘9’), then multiply the RESULT by this digit
               -    If the current character is a letter, add its index from the Latin alphabet to RESULT. 
               -    'A' has an index 0, ‘B’ has an index 1, etc…
               -    If the current character is a symbol, that is different from the ones described above, create module of the RESULT by the provided number (M)*/

            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == '@')
                {
                    break;
                }
                else if (charArray[i] >= '0' && charArray[i] <= '9')
                {
                    result *= charArray[i] - '0';
                }
                else if (charArray[i] >= 'a' && charArray[i] <= 'z')
                {
                    result += charArray[i] - 'a';
                }
                else
                {
                    if (result >= number)
                    {
                        result = result % number;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}

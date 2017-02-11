using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersianRug
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6; //int.Parse(Console.ReadLine());
            int d = 5; //int.Parse(Console.ReadLine());

            int size = n * 2 + 1;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (row + col <= size + d / 2 && row + col > size - (d / 2 + 2) || row - col < (d / 2 + 1) && row - col > -(d / 2 + 1))
                    {
                        Console.WriteLine('#');
                    }
                    else if (row - col == -(d / 2 + 1) || row - col == d / 2 +1)
                    {
                        Console.Write('\\');
                    }
                    else if (row + col == size + d/2 || row + col == size - (d / 2 + 2))
                    {
                        Console.Write('/');
                    }
                    else if (row == n && col == d/ 2 + 1)
                    {
                        Console.Write('X');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                    
                }
            }
        }
    }
}

using System;
using System.Linq;

namespace _02.Guitar
{
    public class Guitar
    {
        public static void Main()
        {
            int c = int.Parse(Console.ReadLine());
            int[] numOfC = (Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            int initialVolume = int.Parse(Console.ReadLine());
            int maxVolume = int.Parse(Console.ReadLine());

            int[,] matrix = new int[c + 1, maxVolume + 1];

            // start
            matrix[0, initialVolume] = 1;

            // Current volumes for change the sound
            for (int row = 1; row <= c; row++)
            {
                // Possible volumes +/- for every new song
                for (int col = 0; col <= maxVolume; col++)
                {
                    if (matrix[row - 1, col] == 1)
                    {
                        int newPossibleVolume = col - numOfC[row - 1];
                        if (newPossibleVolume >= 0)
                        {
                            matrix[row, newPossibleVolume] = 1;
                        }

                        newPossibleVolume = col + numOfC[row - 1];
                        if (newPossibleVolume <= maxVolume)
                        {
                            matrix[row, newPossibleVolume] = 1;
                        }
                    }
                }
            }

            for (int i = maxVolume; i >= 0; i--)
            {
                if (matrix[c, i] == 1)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine(-1);
        }
    }
}

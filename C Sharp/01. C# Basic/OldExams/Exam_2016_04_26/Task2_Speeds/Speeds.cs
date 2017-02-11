using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Speeds
{
    class Speeds
    {
        static void Main()
        {
            int numCars = int.Parse(Console.ReadLine());
            int sum = 0;
            int biggestSum = 0;
            int currentSpeed = 0;
            int counter = 0;
            int biggestGroup = 0;

            for (int i = 0; i < numCars; i++)
            {
                int carSpeed = int.Parse(Console.ReadLine());
                // initial speed
                if (i == 0)
                {
                    currentSpeed = carSpeed;
                }
                // checking for new group
                if (carSpeed < currentSpeed)
                {
                    counter = 0;
                    sum = 0;
                    currentSpeed = carSpeed;
                }

                // checking for equal speeds
                else if (carSpeed == currentSpeed)
                {
                    biggestSum = carSpeed;
                    counter = 0;
                    sum = 0;
                }
                // counting the cars and treir sum of speed
                else
                {
                    counter++;
                    sum += carSpeed;
                    if (counter >= biggestGroup)
                    {
                        if (sum > biggestSum)
                        {
                            biggestSum = sum + currentSpeed;
                        }
                        biggestGroup = counter;
                    }
                }
               
            }
            Console.WriteLine(biggestSum);
        }
    }
}

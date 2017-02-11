using System;


namespace Task3_Numbers
{
    class Numbers
    {
        static void Main()
        {
            double num = Convert.ToDouble(Console.ReadLine());
            double min = double.MaxValue;
            double max = double.MinValue;
            double sum = 0;
            for (int i = 0; i < num; i++)
            {
                double currentNum = Convert.ToDouble(Console.ReadLine());
                if (currentNum > max)
                {
                    max = currentNum;
                }
                if (currentNum < min)
                {
                    min = currentNum;
                }
                sum += currentNum;
            }
            double avg = sum / num;
            Console.WriteLine("min={0:f2}", min);
            Console.WriteLine("max={0:f2}", max);
            Console.WriteLine("sum={0:f2}", sum);
            Console.WriteLine("avg={0:f2}", avg);
        }
    }
}

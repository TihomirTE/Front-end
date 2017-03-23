namespace Task2.PrintStatistics
{
    using System;

    public class Statistics
    {
        public void PrintStatistics(double[] numbers, int length)
        {
            double maxNumber = double.MinValue;
            for (int i = 0; i < length; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }

            PrintResult(maxNumber);

            double minNumber = double.MaxValue;
            for (int i = 0; i < length; i++)
            {
                if (numbers[i] < minNumber)
                {
                    minNumber = numbers[i];
                }
            }

            PrintResult(minNumber);

            int quantityOfNumbers = 0;
            for (int i = 0; i < length; i++)
            {
                quantityOfNumbers += (int)numbers[i];
            }

            int average = quantityOfNumbers / length;
            PrintResult(average);
        }

        private void PrintResult(double result)
        {
            Console.WriteLine(result);
        }
    }
}

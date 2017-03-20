namespace Task3_Loop
{
    using System;

    public class RefactorLoop
    {
        public static void Main()
        {
            var expectedValue = 10;
            var numbers = new int[100];
            var numberFound = 0;
            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(numbers[i]);
                    if (numbers[i] == expectedValue)
                    {
                        numberFound = 666;
                    }
                }
                else
                {
                    Console.WriteLine(numbers[i]);
                }
            }

            // More code here
            if (numberFound == 666)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}

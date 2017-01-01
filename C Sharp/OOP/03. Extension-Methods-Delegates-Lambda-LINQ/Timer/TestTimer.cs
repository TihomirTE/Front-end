namespace Timer
{
    using System;

    // This class test -> Timer class
    public class TestTimer
    {
        static void Main()
        {
            Timer testTimer = new Timer(1, 10);

            //add method to execute
            testTimer.MethodsInTimer = delegate ()
            {
                Console.Write("Executed!");
            };

            //add another method
            testTimer.MethodsInTimer += delegate ()
            {
                Console.WriteLine(" Counter: {0}", testTimer.Counter);
            };

            //test
            testTimer.Start();
        }
    }
}

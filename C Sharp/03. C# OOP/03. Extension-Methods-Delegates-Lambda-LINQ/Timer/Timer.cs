/* Problem 7. Timer
    Using delegates write a class Timer that can execute certain method
    at each t seconds.*/


namespace Timer
{
    using System;
    using System.Threading;

    public class Timer
    {
        // fields
        public delegate void MethodsToExecute();
        public MethodsToExecute MethodsInTimer;
        private readonly int interval = 0;
        private readonly int totalTime;
        private int counter = 1;

        // constructors
        public Timer(int interval, int totalTime)
        {
            this.interval = interval;
            this.totalTime = totalTime;
        }

        public Timer() : this(0, 25) { }

        // counter property
        public int Counter
        {
            get { return this.counter; }
        }

        // start of timer
        public void Start()
        {
            DateTime end = DateTime.Now.AddSeconds(totalTime);
            while (DateTime.Now < end)
            {
                MethodsInTimer();
                Thread.Sleep(interval * 1000);
                counter++;
            }
        }
    }
}

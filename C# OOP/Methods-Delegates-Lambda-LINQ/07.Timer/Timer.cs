using System;
using System.Threading;


namespace _7.Timer
{
    public delegate void MethodToExecute();
    public class Timer
    {       

        public MethodToExecute method;

        public void Start(int intervalInSeconds, int totalTimeInSeconds)
        {
            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(totalTimeInSeconds);
            while (start <= end)
            {

                method();
                Thread.Sleep(intervalInSeconds * 1000);
                start = DateTime.Now;
            }

        }
    }
}
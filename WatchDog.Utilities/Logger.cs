using System;

namespace WatchDog.Utilities
{
    public class Logger : ILogger
    {
        public void Information(string message)
        {
            System.Diagnostics.Trace.WriteLine(message);
        }

        public void Exception(Exception ex)
        {
            System.Diagnostics.Trace.Write(ex.ToString());
        }
    }
}
using System;

namespace WatchDog.Utilities
{
    public interface ILogger
    {
        void Information(string message);
        void Exception(Exception ex);
    }
}

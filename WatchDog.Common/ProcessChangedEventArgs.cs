using System;

namespace WatchDog.Domain
{
    public class ProcessChangedEventArgs : EventArgs
    {
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public string Status { get; set; }
    }
}
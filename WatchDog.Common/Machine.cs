using System;
using System.Collections.Generic;

namespace WatchDog.Domain
{
    public class Machine
    {
        public Machine()
        {
            Environment = new Environment();
            Sensors = new Dictionary<string, SensorModified>();
            ReadingDate = DateTime.Now;
        }

        public Environment Environment { get; set; }
        public IDictionary<string, SensorModified> Sensors { get; set; }
        public DateTime ReadingDate { get; set; }
    }
}

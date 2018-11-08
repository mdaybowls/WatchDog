using System.Collections.Generic;

namespace WatchDog.Domain
{
    public class Environment
    {
        public Environment()
        {
            MachineName = System.Environment.MachineName;
            TickCount = System.Environment.TickCount;
            OSVersionString = System.Environment.OSVersion.VersionString;
            IPAddress = new List<string>();

            var strHostName = System.Net.Dns.GetHostName();
            var ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            foreach (var addr in ipEntry.AddressList)
            {
                IPAddress.Add(addr.ToString());
            }
        }

        public string MachineName { get; set; }
        public int TickCount { get; set; }
        public string OSVersionString { get; set; }
        public ICollection<string> IPAddress { get; set; }
    }
}

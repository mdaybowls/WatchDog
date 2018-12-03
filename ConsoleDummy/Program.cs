using System;
using System.Globalization;

namespace ConsoleDummy
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)}: Application is Running...");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}

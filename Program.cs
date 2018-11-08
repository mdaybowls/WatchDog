using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using WatchDog.Azure.ServiceBus;
using WatchDog.Domain;

namespace MinerWatchDog
{
    public class Program
    {
        //public static IDictionary<string, SensorModified> SensorList;

        public class UpdateVisitor : IVisitor
        {
            public void VisitComputer(IComputer computer)
            {
                computer.Traverse(this);
            }
            public void VisitHardware(IHardware hardware)
            {
                hardware.Update();
                foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
            }
            public void VisitSensor(ISensor sensor) { }
            public void VisitParameter(IParameter parameter) { }
        }
        static Machine GetSystemInfo()
        {
            var machine = new Machine();

            UpdateVisitor updateVisitor = new UpdateVisitor();
            Computer computer = new Computer();
            computer.Open();
            computer.CPUEnabled = true;
            computer.GPUEnabled = true;
            computer.Accept(updateVisitor);
            for (int i = 0; i < computer.Hardware.Length; i++)
            {
                var hardware = computer.Hardware[i];

                if (hardware.HardwareType == HardwareType.CPU ||
                    hardware.HardwareType == HardwareType.GpuNvidia ||
                    hardware.HardwareType == HardwareType.GpuAti)
                {

                    for (int j = 0; j < hardware.Sensors.Length; j++)
                    {
                        var sensor = hardware.Sensors[j];
                        UpdateSensor(machine, sensor);
                    }
                }
            }
            computer.Close();
            return machine;
        }
        static void Main(string[] args)
        {
            try
            {
                var messageQueue = new MessageQueue();                
                while (true)
                {
                    var machine = GetSystemInfo();
                    messageQueue.SendMessage(machine).Wait();
                    System.Threading.Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            Console.ReadKey();
        }

        private static void UpdateSensor(Machine machine, ISensor sensor)
        {
            var id = sensor.Identifier.ToString();
            if (!sensor.Value.HasValue)
                return;

            var value = (float)sensor.Value;
            SensorModified newSensor;

            if (!machine.Sensors.ContainsKey(id))
            {
                newSensor = new SensorModified();
                newSensor.Value = value;
                newSensor.Min = value;
                newSensor.Max = value;
                newSensor.Avg = value;
                newSensor.Name = sensor.Name;
                newSensor.Identifier = sensor.Identifier.ToString();
                newSensor.SensorType = sensor.SensorType.ToString();
                newSensor.Count = 1;
                machine.Sensors.Add(id, newSensor);
            }
            else
            {
                newSensor = machine.Sensors[id];
                newSensor.Avg = (int)(newSensor.Avg * newSensor.Count + value) / (newSensor.Count + 1);
                newSensor.Count += 1;
                if (value < newSensor.Min)
                    newSensor.Min = value;
                if (value > newSensor.Max)
                    newSensor.Max = value;
            }

            if (newSensor.SensorType == SensorType.Fan.ToString())
            {
                var pct = (int)(newSensor.Value / 4580 * 100);
                Console.WriteLine(newSensor.Name +
                    newSensor.SensorType + ":" +
                    newSensor.Identifier + ":RPM=" +
                    newSensor.Value + ":Min=" +
                    newSensor.Min + ":Max=" +
                    newSensor.Max + ":Avg=" +
                    newSensor.Avg + ":Pct=" +
                    pct +
                    "\r");
            }
            else
            {
                Console.WriteLine(sensor.Name + "-" +
                    sensor.SensorType.ToString() + ":" +
                    sensor.Value.ToString() + "\r");
            }
        }
    }
}
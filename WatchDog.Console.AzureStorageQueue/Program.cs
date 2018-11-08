using WatchDog.Domain;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using WatchDog.Azure.StorageQueue;

namespace WatchDog.Console.AzureStorageQueue
{
    class Program
    {
        public static IDictionary<string, SensorModified> SensorList;

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
        static void GetSystemInfo()
        {
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
                        UpdateSensor(sensor);
                    }
                }
            }
            computer.Close();
        }
        static void Main(string[] args)
        {
            try
            {
                var messageQueue = new MessageQueue();
                SensorList = new Dictionary<string, SensorModified>();
                while (true)
                {
                    GetSystemInfo();
                    messageQueue.SendMessage(SensorList);
                    System.Threading.Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex);
            }
            System.Console.ReadKey();
        }

        private static void UpdateSensor(ISensor sensor)
        {
            var id = sensor.Identifier.ToString();
            if (!sensor.Value.HasValue)
                return;

            var value = (float)sensor.Value;
            SensorModified newSensor;

            if (!SensorList.ContainsKey(id))
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
                SensorList.Add(id, newSensor);
            }
            else
            {
                newSensor = SensorList[id];
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
                System.Console.WriteLine(newSensor.Name +
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
                System.Console.WriteLine(sensor.Name + "-" +
                    sensor.SensorType.ToString() + ":" +
                    sensor.Value.ToString() + "\r");
            }
        }
    }
}

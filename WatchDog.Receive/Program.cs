using System;
using System.Collections.Generic;
using OpenHardwareMonitor.Hardware;
using WatchDog.Domain;
//using WatchDog.Azure.ServiceBus;

namespace WatchDog.Receive
{
    public class Program
    {
        public static IDictionary<string, SensorModified> SensorList;

        static void Main(string[] args)
        {
            try
            {
                //var messageQueue = new MessageQueue();
                //int i = 0;

                //while (true)
                //{
                //    var messageContent = messageQueue.ReceiveMessageAsync();
                //    Console.WriteLine(messageContent.Result);
                //    Console.WriteLine(++i);
                //}
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            Console.ReadKey();
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
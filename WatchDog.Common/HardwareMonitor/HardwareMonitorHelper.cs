using OpenHardwareMonitor.Hardware;

namespace WatchDog.Domain.HardwareMonitor
{
    public class HardwareMonitorHelper
    {
        public Machine GetSystemInfo()
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
                    foreach (var sensor in hardware.Sensors)
                    {
                        UpdateSensor(machine, sensor);
                    }
                }
            }
            computer.Close();
            return machine;
        }

        private void UpdateSensor(Machine machine, ISensor sensor)
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
                // Getting Ip address of local machine...
                // First get the host name of local machine.
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
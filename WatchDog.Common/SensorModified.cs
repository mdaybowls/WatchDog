namespace WatchDog.Domain
{
    public class SensorModified
    {
        public SensorModified()
        {
        }

        public float Min { get; set; }
        public float Max { get; set; }
        public float Avg { get; set; }
        public long Count { get; set; }
        public string SensorType { get; set; }
        public float Value { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
    }
}
namespace WatchDog.Domain.Messaging
{
    public enum CommandType
    {
        RestartMiner
    }

    public class MinerCommandMessage
    {
        public string MachineName { get; set; }
        public CommandType CommandType { get; set; }
    }
}
using System;
using Newtonsoft.Json;
using WatchDog.Domain.Interfaces;
using WatchDog.Utilities;

namespace WatchDog.Domain.Messaging
{
    public class SubscriptionMessageHandler : ISubscriptionMessageHandler
    {
        private readonly ILogger _logger;
        public event EventHandler<SubscriptionEventArgs> MessageReceived;

        public SubscriptionMessageHandler(ILogger logger)
        {
            _logger = logger;
        }

        public void HandleMessage(string message)
        {
            _logger.Information(message);
            var minerCommand = JsonConvert.DeserializeObject<MinerCommandMessage>(message);
            if (minerCommand.MachineName == System.Environment.MachineName)
                OnMessageReceived(minerCommand);
        }

        protected virtual void OnMessageReceived(MinerCommandMessage minerCommandMessage)
        {
            var subEventArgs = new SubscriptionEventArgs
            {
                MinerCommandMessage = minerCommandMessage
            };
            MessageReceived?.Invoke(this, subEventArgs);
        }
    }
}
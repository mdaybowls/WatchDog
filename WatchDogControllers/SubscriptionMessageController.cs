using System;
using WatchDog.Azure.ServiceBus;
using WatchDog.Domain.Interfaces;
using WatchDog.Domain.Messaging;
using WatchDog.Utilities;

namespace WatchDog.Controllers
{
    public class SubscriptionMessageController
    {
        private readonly MessageReceiver _messageReceiver;
        public event EventHandler OnRestartMiner;

        public SubscriptionMessageController(ILogger logger, ISubscriptionMessageHandler messageHandler)
        {            
            messageHandler.MessageReceived += MessageReceived;
            _messageReceiver = new MessageReceiver(logger, messageHandler);

        }

        public void StartReceiving()
        {
            _messageReceiver.Start();
        }

        protected virtual void OnOnRestartMiner()
        {
            OnRestartMiner?.Invoke(this, EventArgs.Empty);
        }

        private void MessageReceived(object sender, SubscriptionEventArgs e)
        {
            if (e.MinerCommandMessage.CommandType == CommandType.RestartMiner)
                OnOnRestartMiner();
        }

    }
}

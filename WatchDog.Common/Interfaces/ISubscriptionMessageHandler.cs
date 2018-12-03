using System;
using System.Threading.Tasks;
using WatchDog.Domain.Messaging;

namespace WatchDog.Domain.Interfaces
{
    public interface ISubscriptionMessageHandler
    {
        event EventHandler<SubscriptionEventArgs> MessageReceived;
        void HandleMessage(string message);
    }
}
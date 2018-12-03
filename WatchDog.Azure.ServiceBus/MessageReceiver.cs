using System.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using WatchDog.Domain.Interfaces;
using WatchDog.Utilities;

namespace WatchDog.Azure.ServiceBus
{
    public class MessageReceiver
    {
        private readonly string _serviceBusConnectionString;
        private readonly string _topicName;
        private readonly string _subscriptionName;
        private ISubscriptionClient _subscriptionClient;
        private ISubscriptionMessageHandler _messageHandler;
        private readonly ILogger _logger;

        public MessageReceiver(ILogger logger, ISubscriptionMessageHandler messageHandler)
        {
            _serviceBusConnectionString = ConfigurationManager.AppSettings["ServiceBusConnectionString"];
            _topicName = ConfigurationManager.AppSettings["TopicName"];
            _subscriptionName = ConfigurationManager.AppSettings["SubscriptionName"];
            _logger = logger;
            _messageHandler = messageHandler;
        }

        public void Start()
        {
            _subscriptionClient = new SubscriptionClient(_serviceBusConnectionString, _topicName, _subscriptionName);

            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        public async Task Stop()
        {
            await _subscriptionClient.CloseAsync();
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var messageBody = Encoding.UTF8.GetString(message.Body);
            _messageHandler.HandleMessage(messageBody);
            await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            _logger.Exception(exceptionReceivedEventArgs.Exception);
            return Task.CompletedTask;
        }
    }
}
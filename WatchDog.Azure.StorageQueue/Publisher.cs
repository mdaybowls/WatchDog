using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using Microsoft.ServiceBus;

namespace WatchDog.Azure.StorageQueue
{
    public class Publisher
    {
        public async Task SendMessageAsync(string messageString)
        {
            var topic = new TopicClient(
                "Endpoint=sb://bowlerpro.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9BngpiBrOt5KoXSVvkbXreqa49W4JI4Y1q36IQer56o=",
                "topic1");
            var message = new Message(Encoding.UTF8.GetBytes(messageString));
            await topic.SendAsync(message);
        }
    }
}
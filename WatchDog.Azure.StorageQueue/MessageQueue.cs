using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Queue; // Namespace for Queue storage types
using WatchDog.Domain;
using Newtonsoft.Json;

namespace WatchDog.Azure.StorageQueue
{
    public class MessageQueue
    {
        public void SendMessage(Machine machine)
        {
            var messageJson = JsonConvert.SerializeObject(machine);
            var storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));
            var queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a queue.
            var queue = queueClient.GetQueueReference("myqueue-items");

            // Create the queue if it doesn't already exist.
            queue.CreateIfNotExists();

            // Create a message and add it to the queue.
            var message = new CloudQueueMessage(messageJson);
            queue.AddMessage(message);            
        }
    }
}

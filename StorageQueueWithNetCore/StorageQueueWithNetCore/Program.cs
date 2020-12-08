using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StorageQueueWithNetCore
{
    class Program
    {
        private readonly static string ConnectionString = "";
        private readonly static string QueueName = "samplestoragequeue";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            QueueClient queue = await StorageQueueObjects.CreateQueue(QueueName, ConnectionString);

            //insert 50 messages
            for (int i = 0; i < 50; i++)
            {
                await SendAndReceiveMessage.InsertMessage(queue, "Message Number " + i);
            }

            PeekedMessage[] peekedMessages = await SendAndReceiveMessage.PeekMessage(queue);
            peekedMessages.ToList().ForEach(x => Console.WriteLine("Message peeked: " + x.Body));

            QueueMessage[] message = await SendAndReceiveMessage.DequeueMessage(queue);
            Console.WriteLine("Single Message dequeued: " + message[0].Body);

            QueueMessage[] messages = await SendAndReceiveMessage.DequeueMessages(queue);
            messages.ToList().ForEach(x => Console.WriteLine("Message dequeued: " + x.Body));

            await StorageQueueObjects.DeleteQueue(QueueName, ConnectionString);
        }
    }
}

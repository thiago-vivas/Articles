using Azure.Messaging.ServiceBus.Administration;
using System;
using System.Threading.Tasks;

namespace ServiceBusWithNetCore
{
    class Program
    {
        private static readonly string ConnectionString = "Endpoint=sb://sampleservbusnamespace.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=+SXXUY4kweUSphE1l78avtHWrp9NyDGKPiePOi/KWfw=";
        private static readonly string QueueName = "sampleQueue";
        private static readonly string SessionQueueName = "sampleSessionQueue";
        private static readonly string TopicName = "sampleTopic";
        private static readonly string SubscriptionName = "sampleSubscription";
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region Creating Objects
            QueueProperties queue = await ServiceBusObjects.GetQueueAsync(ConnectionString, QueueName);
            if (queue == null)
                queue = await ServiceBusObjects.CreateQueueAsync(ConnectionString, QueueName);

            QueueProperties sessionQueue = await ServiceBusObjects.GetQueueAsync(ConnectionString, SessionQueueName);
            if (sessionQueue == null)
                sessionQueue = await ServiceBusObjects.CreateQueueAsync(ConnectionString, SessionQueueName, true);

            TopicProperties topic = await ServiceBusObjects.GetTopicAsync(TopicName, ConnectionString);
            if (topic == null)
                topic = await ServiceBusObjects.CreateTopicAsync(TopicName, ConnectionString);

            SubscriptionProperties subscription = await ServiceBusObjects.GetSubscriptionAsync(TopicName, ConnectionString, SubscriptionName);
            if (subscription == null)
                subscription = await ServiceBusObjects.CreateSubscriptionAsync(TopicName, ConnectionString, SubscriptionName);

            #endregion

            #region Sending and Receiving Messages
            int count = 0;

            //sending messages
            await SendAndReceiveMessage.SendMessageAsync(ConnectionString, QueueName, $"Message {count++}");
            await SendAndReceiveMessage.SendMessageBatchAsync(ConnectionString, QueueName, new System.Collections.Generic.List<string> { $"Message {count++}", $"Message {count++}", $"Message {count++}", $"Message {count++}" });
            await SendAndReceiveMessage.SendMessageSafeBatchAsync(ConnectionString, QueueName, new System.Collections.Generic.List<string> { $"Message {count++}", $"Message {count++}", $"Message {count++}", $"Message {count++}" });
            long firstScheduledMessageNumber = await SendAndReceiveMessage.SendScheduledMessageAsync(ConnectionString, QueueName, $"Message {count++}", new DateTimeOffset(DateTime.Now.AddMinutes(10)));
            long secondScheduledMessageNumber = await SendAndReceiveMessage.SendScheduledMessageAsync(ConnectionString, QueueName, $"Message {count++}", new DateTimeOffset(DateTime.Now.AddMinutes(10)));
            await SendAndReceiveMessage.CancelScheduledMessageAsync(ConnectionString, QueueName, firstScheduledMessageNumber);
            long deferredMessageNumber = await SendAndReceiveMessage.DeferMessageAsync(ConnectionString, QueueName);
            Console.WriteLine((await SendAndReceiveMessage.GetDeferredMessageAsync(ConnectionString, QueueName, deferredMessageNumber)).Body);
            await SendAndReceiveMessage.DeadLetterMessageAsync(ConnectionString, QueueName);
            Console.WriteLine((await SendAndReceiveMessage.GetDeadLetterMessageAsync(ConnectionString, QueueName)).Body);
            Console.WriteLine((await SendAndReceiveMessage.GetMessageAsync(ConnectionString, QueueName)).Body);
            await SendAndReceiveMessage.CompleteOrAbandonMessageAsync(ConnectionString, QueueName, false);
            await SendAndReceiveMessage.CompleteOrAbandonMessageAsync(ConnectionString, QueueName, true);
            #endregion

            #region Sending and Receiving Session Messages
            await SendAndReceiveMessage.SendSessionMessageAsync(ConnectionString, SessionQueueName, $"Message {count++}", "session id 1");
            Console.WriteLine((await SendAndReceiveMessage.GetMessageFromSessionAsync(ConnectionString, SessionQueueName, "session id 1")).Body);
            #endregion

            #region Messages Processor
            await Processor.RunProcessor(ConnectionString, QueueName, new TimeSpan(0,0,10));
            #endregion

            #region Session Processor
            await SessionProcessor.RunSessionProcessor(ConnectionString, SessionQueueName, new TimeSpan(0,0,10));

            #endregion

        }


    }
}

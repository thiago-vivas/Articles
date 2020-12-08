using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;

namespace ServiceBusWithNetCore
{
    public class SendAndReceiveMessage
    {
        public static async Task SendMessageAsync(string connectionString, string queueName, string messageText)
        {
            await using var client = new ServiceBusClient(connectionString);

            // create the sender
            ServiceBusSender sender = client.CreateSender(queueName);

            // create a message that we can send. UTF-8 encoding is used when providing a string.
            ServiceBusMessage message = new ServiceBusMessage(messageText);

            // send the message
            await sender.SendMessageAsync(message);
        }
        public static async Task SendSessionMessageAsync(string connectionString, string queueName, string messageText, string sessionId)
        {
            await using var client = new ServiceBusClient(connectionString);

            // create the sender
            ServiceBusSender sender = client.CreateSender(queueName);

            // create a message that we can send. UTF-8 encoding is used when providing a string.
            ServiceBusMessage message = new ServiceBusMessage(messageText)
            {
                SessionId = sessionId
            };

            // send the message
            await sender.SendMessageAsync(message);
        }
        public static async Task<long> SendScheduledMessageAsync(string connectionString, string queueName, string messageText, DateTimeOffset timeOffset)
        {
            await using var client = new ServiceBusClient(connectionString);

            // create the sender
            ServiceBusSender sender = client.CreateSender(queueName);

            // create a message that we can send. UTF-8 encoding is used when providing a string.
            ServiceBusMessage message = new ServiceBusMessage(messageText);

            // send the message
            return await sender.ScheduleMessageAsync(message, timeOffset);
        }


        public static async Task CancelScheduledMessageAsync(string connectionString, string queueName, long messageSequenceNumber)
        {
            await using var client = new ServiceBusClient(connectionString);

            // create the sender
            ServiceBusSender sender = client.CreateSender(queueName);

            await sender.CancelScheduledMessageAsync(messageSequenceNumber);

        }
        public static async Task<long> DeferMessageAsync(string connectionString, string queueName)
        {
            await using var client = new ServiceBusClient(connectionString);

            // create a receiver that we can use to receive the message
            ServiceBusReceiver receiver = client.CreateReceiver(queueName);

            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

            // defer the message, thereby preventing the message from being received again without using
            // the received deferred message API.
            await receiver.DeferMessageAsync(receivedMessage);

            return receivedMessage.SequenceNumber;

        }

        public static async Task<ServiceBusReceivedMessage> GetDeferredMessageAsync(string connectionString, string queueName, long messageSequenceNumber)
        {
            await using var client = new ServiceBusClient(connectionString);

            // create a receiver that we can use to receive the message
            ServiceBusReceiver receiver = client.CreateReceiver(queueName);

            // receive the deferred message by specifying the service set sequence number of the original
            // received message
            return await receiver.ReceiveDeferredMessageAsync(messageSequenceNumber);
        }

        public static async Task DeadLetterMessageAsync(string connectionString, string queueName)
        {
            await using var client = new ServiceBusClient(connectionString);

            // create a receiver that we can use to receive the message
            ServiceBusReceiver receiver = client.CreateReceiver(queueName);

            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

            // dead-letter the message, thereby preventing the message from being received again without receiving from the dead letter queue.
            await receiver.DeadLetterMessageAsync(receivedMessage);
        }
        public static async Task<ServiceBusReceivedMessage> GetDeadLetterMessageAsync(string connectionString, string queueName)
        {
            await using var client = new ServiceBusClient(connectionString);

            // receive the dead lettered message with receiver scoped to the dead letter queue.
            ServiceBusReceiver receiver = client.CreateReceiver(queueName, new ServiceBusReceiverOptions
            {
                SubQueue = SubQueue.DeadLetter
            });

            // the received message is a different type as it contains some service set properties
            return await receiver.ReceiveMessageAsync();
        }

        public static async Task<ServiceBusReceivedMessage> GetMessageAsync(string connectionString, string queueName)
        {
            await using var client = new ServiceBusClient(connectionString);

            // create a receiver that we can use to receive the message
            ServiceBusReceiver receiver = client.CreateReceiver(queueName);

            // the received message is a different type as it contains some service set properties
            return await receiver.ReceiveMessageAsync();
        }
        public static async Task<ServiceBusReceivedMessage> GetMessageFromSessionAsync(string connectionString, string queueName, string sessionId)
        {
            await using var client = new ServiceBusClient(connectionString);

            ServiceBusSessionReceiver receiver = null;
            if (string.IsNullOrEmpty(sessionId))
                receiver = await client.AcceptNextSessionAsync(queueName);
            else
                receiver = await client.AcceptSessionAsync(queueName, sessionId);

            // the received message is a different type as it contains some service set properties
            return await receiver.ReceiveMessageAsync();
        }
        public static async Task CompleteOrAbandonMessageAsync(string connectionString, string queueName, bool abandon)
        {
            await using var client = new ServiceBusClient(connectionString);

            // create a receiver that we can use to receive the message
            ServiceBusReceiver receiver = client.CreateReceiver(queueName);

            // the received message is a different type as it contains some service set properties
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

            Console.WriteLine($"Message received {receivedMessage.Body} to be abandoned {abandon}");

            if (!abandon) // complete the message, thereby deleting it from the service
                await receiver.CompleteMessageAsync(receivedMessage);
            else // abandon the message, thereby releasing the lock and allowing it to be received again by this or other receivers
                await receiver.AbandonMessageAsync(receivedMessage);
        }


        public static async Task SendMessageBatchAsync(string connectionString, string queueName, List<string> messageTexts)
        {
            await using var client = new ServiceBusClient(connectionString);

            // create the sender
            ServiceBusSender sender = client.CreateSender(queueName);

            // create a message that we can send. UTF-8 encoding is used when providing a string.
            IList<ServiceBusMessage> messages = new List<ServiceBusMessage>();

            messageTexts.ForEach(msg => messages.Add(new ServiceBusMessage(msg)));

            // send the message
            await sender.SendMessagesAsync(messages);
        }
        public static async Task SendMessageSafeBatchAsync(string connectionString, string queueName, List<string> messageTexts)
        {
            await using var client = new ServiceBusClient(connectionString);

            // create the sender
            ServiceBusSender sender = client.CreateSender(queueName);

            // create a message that we can send. UTF-8 encoding is used when providing a string.
            Queue<ServiceBusMessage> messages = new Queue<ServiceBusMessage>();

            messageTexts.ForEach(msg => messages.Enqueue(new ServiceBusMessage(msg)));

            while (messages.Count > 0)
            {
                // start a new batch
                using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

                // add the first message to the batch
                if (messageBatch.TryAddMessage(messages.Peek()))
                {
                    // dequeue the message from the .NET queue once the message is added to the batch
                    messages.Dequeue();
                }
                else
                {
                    // if the first message can't fit, then it is too large for the batch
                    throw new Exception($"Message {messageTexts.Count - messages.Count} is too large and cannot be sent.");
                }

                // add as many messages as possible to the current batch
                while (messages.Count > 0 && messageBatch.TryAddMessage(messages.Peek()))
                {
                    // dequeue the message from the .NET queue as it has been added to the batch
                    messages.Dequeue();
                }

                // now, send the batch
                await sender.SendMessagesAsync(messageBatch);

            }
        }
    }
}

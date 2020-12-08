using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StorageQueueWithNetCore
{
    public class SendAndReceiveMessage
    {
        //-------------------------------------------------
        // Send a message to the queue
        //-------------------------------------------------
        public static async Task<Azure.Response<SendReceipt>> InsertMessage(QueueClient queueClient, string message)
        {
            return await queueClient.SendMessageAsync(message);
        }
        //-------------------------------------------------
        // Peek at a message in the queue
        //-------------------------------------------------
        public static async Task<Azure.Response<PeekedMessage[]>> PeekMessage(QueueClient queueClient)
        {
            return await queueClient.PeekMessagesAsync();
        }

        //-------------------------------------------------
        // Process and remove one message from the queue
        //-------------------------------------------------
        public static async Task<QueueMessage[]> DequeueMessage(QueueClient queueClient)
        {
            // Get the next message
            QueueMessage[] retrievedMessage = await queueClient.ReceiveMessagesAsync();


            // Delete the message
            await queueClient.DeleteMessageAsync(retrievedMessage[0].MessageId, retrievedMessage[0].PopReceipt);

            return retrievedMessage;
        }


        //-----------------------------------------------------
        // Process and remove multiple messages from the queue
        //-----------------------------------------------------
        public static async Task<QueueMessage[]> DequeueMessages(QueueClient queueClient)
        {
            // Receive and process 20 messages
            QueueMessage[] receivedMessages = await queueClient.ReceiveMessagesAsync(20, TimeSpan.FromMinutes(5));

            foreach (QueueMessage message in receivedMessages)
            {
                // Delete the message
                await queueClient.DeleteMessageAsync(message.MessageId, message.PopReceipt);
            }

            return receivedMessages;
        }
    }
}

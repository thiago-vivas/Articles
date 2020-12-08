using Azure.Storage.Queues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StorageQueueWithNetCore
{
    public class StorageQueueObjects
    {
        //-------------------------------------------------
        // Create the queue
        //-------------------------------------------------
        public async static Task<QueueClient> CreateQueue(string queueName, string connectionString)
        {
            // Instantiate a QueueClient which will be used to create and manipulate the queue
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // Create the queue
            await queueClient.CreateIfNotExistsAsync();

            return queueClient;
        }

        //-------------------------------------------------
        // Delete the queue
        //-------------------------------------------------
        public async static Task<Azure.Response<bool>> DeleteQueue(string queueName, string connectionString)
        {
            // Instantiate a QueueClient which will be used to manipulate the queue
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // Delete the queue
            return await queueClient.DeleteIfExistsAsync();
        }
    }
}

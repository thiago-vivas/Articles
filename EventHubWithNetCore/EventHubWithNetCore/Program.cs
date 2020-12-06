using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;

namespace EventHubWithNetCore
{
    class Program
    {
        private const string ehubNamespaceConnectionString = "Endpoint=sb://eventhubwithnetcore.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ARWoRUTA++GrBmNnumYvDBveo2Gkrs7cMFUCYH9euic=";
        private const string eventHubName = "sampleeventhub";
        private const string blobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=storageaccountcloud8c65;AccountKey=oRVheUO8Xs/5PiimGjJoOwCA7Ee0YMCh4HQXAicCzg8noRYZMT8M2oWbyevLeodvmtv099Yj0UPJeFL23/K8RQ==;EndpointSuffix=core.windows.net";
        private const string blobContainerName = "sampleblobcontainer";
        static async Task Main(string[] args)
        {
            // Read from the default consumer group: $Default
            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            // Create a blob container client that the event processor will use 
            BlobContainerClient storageClient = new BlobContainerClient(blobStorageConnectionString, blobContainerName);

            // Create an event processor client to process events in the event hub
            EventProcessorClient processorClinet = new EventProcessorClient(storageClient, consumerGroup, ehubNamespaceConnectionString, eventHubName);

            // Register handlers for processing events and handling errors
            processorClinet.ProcessEventAsync += ProcessEventHandler;
            processorClinet.ProcessErrorAsync += ProcessErrorHandler;

            // Start processing
            await processorClinet.StartProcessingAsync();

            // Processing time
            DateTime finishProcessing = DateTime.Now.AddMinutes(10);
            
            while (DateTime.Now < finishProcessing)
            {
                // Wait for 10 seconds for the events to be processed
                await Task.Delay(TimeSpan.FromSeconds(10));
            }

            // Stop processing
            await processorClinet.StopProcessingAsync();
        }

        static async Task ProcessEventHandler(ProcessEventArgs eventArgs)
        {
            // Write the body of the event to the console window
            Console.WriteLine("\tRecevied event: {0}", Encoding.UTF8.GetString(eventArgs.Data.Body.ToArray()));

            // Update checkpoint in the blob storage so that the app receives only new events the next time it's run
            await eventArgs.UpdateCheckpointAsync(eventArgs.CancellationToken);
        }

        static Task ProcessErrorHandler(ProcessErrorEventArgs eventArgs)
        {
            // Write details about the error to the console window
            Console.WriteLine($"\tPartition '{ eventArgs.PartitionId}': an unhandled exception was encountered.");
            Console.WriteLine(eventArgs.Exception.Message);
            return Task.CompletedTask;
        }
    }
}

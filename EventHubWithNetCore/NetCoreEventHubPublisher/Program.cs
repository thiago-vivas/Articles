using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;

namespace NetCoreEventHubPublisher
{
    class Program
    {
        private const string connectionString = "Endpoint=sb://eventhubwithnetcore.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ARWoRUTA++GrBmNnumYvDBveo2Gkrs7cMFUCYH9euic=";
        private const string eventHubName = "sampleeventhub";
        static async Task Main(string[] args)
        {
            Random random = new Random();
            int numberOfEvents = random.Next(5, 10);
            await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
            {
                // Create a batch of events 
                using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();


                // Add events to the batch. An event is a represented by a collection of bytes and metadata. 
                for (int i = 0; i < numberOfEvents; i++)
                {
                    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes($"Event number {i}")));
                }

                // Use the producer client to send the batch of events to the event hub
                await producerClient.SendAsync(eventBatch);
                Console.WriteLine($"A batch of {numberOfEvents} events has been published.");
            }
        }
    }
}

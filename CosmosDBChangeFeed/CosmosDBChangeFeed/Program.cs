using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosDBChangeFeed
{
    class Program
    {
        private static readonly string endpointUri = "https://localhost:8081/";
        private static readonly string primaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private static readonly string databaseName = "sampleDatabase";
        private static readonly string sourceContainerName = "sampleSourceContainer";
        private static readonly string leaseContainerName = "sampleLeaseContainer";
        static async Task Main(string[] args)
        {
            CosmosClient cosmosClient = new CosmosClientBuilder(endpointUri, primaryKey).Build();

            Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);

            await database.CreateContainerIfNotExistsAsync(new ContainerProperties(sourceContainerName, "/id"));

            await database.CreateContainerIfNotExistsAsync(new ContainerProperties(leaseContainerName, "/id"));

            ChangeFeedProcessor processor = await StartChangeFeedProcessorAsync(cosmosClient);

            await GenerateItemsAsync(cosmosClient);
        }

        private static async Task<ChangeFeedProcessor> StartChangeFeedProcessorAsync(
    CosmosClient cosmosClient)
        {

            Container leaseContainer = cosmosClient.GetContainer(databaseName, leaseContainerName);
            ChangeFeedProcessor changeFeedProcessor = cosmosClient.GetContainer(databaseName, sourceContainerName)
                .GetChangeFeedProcessorBuilder<Person>(processorName: "changeFeedSample", HandleChangesAsync)
                    .WithInstanceName("consoleHost")
                    .WithLeaseContainer(leaseContainer)
                    .Build();

            Console.WriteLine("Starting Change Feed Processor...");
            await changeFeedProcessor.StartAsync();
            Console.WriteLine("Change Feed Processor started.");
            return changeFeedProcessor;
        }
        static async Task HandleChangesAsync(IReadOnlyCollection<Person> changes, CancellationToken cancellationToken)
        {
            Console.WriteLine("Started handling changes...");
            foreach (Person item in changes)
            {
                Console.WriteLine($"Detected operation for person with id {item.Id}, created at {item.CreationDate}.");
                // Simulate some asynchronous operation
                await Task.Delay(10);
            }

            Console.WriteLine("Finished handling changes.");
        }

        private static async Task GenerateItemsAsync(CosmosClient cosmosClient)
        {
            Container sourceContainer = cosmosClient.GetContainer(databaseName, sourceContainerName);
            while (true)
            {
                Console.WriteLine("Enter a number of people to insert in the container or 'exit' to stop:");
                string command = Console.ReadLine();
                if ("exit".Equals(command, StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine();
                    break;
                }

                if (int.TryParse(command, out int itemsToInsert))
                {
                    Console.WriteLine($"Generating {itemsToInsert} people...");
                    for (int i = 0; i < itemsToInsert; i++)
                    {
                        var person = GetPerson();
                        await sourceContainer.CreateItemAsync<Person>(person,
                            new PartitionKey(person.Id));
                    }
                }
            }

        }
        private static Person GetPerson()
        {
            Random random = new Random();
            return new Person
            {
                BirthDate = DateTime.Now.AddYears(30),
                Id = random.Next() + "Thiago",
                Name = "Thiago",
                LastName = "Araujo",
                CreationDate = DateTime.Now,
                Vehicle = new Vehicle
                {
                    Id = random.Next(),
                    Make = "Audi",
                    Model = "TT",
                    Year = random.Next()
                },
                Address = new Address
                {
                    Id = random.Next(),
                    City = "Lisbon",
                    StreetAndNumber = "Rua 25 de Abril, 4"
                }
            };
        }
    }
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string StreetAndNumber { get; set; }

    }
    public class Vehicle
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }

    }

}

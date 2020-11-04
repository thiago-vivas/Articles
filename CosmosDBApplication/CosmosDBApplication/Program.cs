using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CosmosDBApplication
{
    class Program
    {
        private static readonly string endpointUri = "https://sampleazurecosmosdb.documents.azure.com:443/";
        private static readonly string primaryKey = "BD43cPOWtjdSsSeBTpy2rbJLIW4lMzhGoNkiVKX6y32cTQ2E2f139J0r8xxS3YR8Sy1bQywls9ByISabRjuaUQ==";
        public static async Task Main(string[] args)
        {
            using (CosmosClient client = new CosmosClient(endpointUri, primaryKey))
            {
                DatabaseResponse databaseResponse = await client.CreateDatabaseIfNotExistsAsync("SampleCosmosDB");
                Database sampleDatabase = databaseResponse.Database;

                await Console.Out.WriteLineAsync($"Database Id:\t{sampleDatabase.Id}");

                IndexingPolicy indexingPolicy = new IndexingPolicy
                {
                    IndexingMode = IndexingMode.Consistent,
                    Automatic = true,
                    IncludedPaths =
                    {
                        new IncludedPath
                        {
                            Path = "/*"
                        }
                    }
                };
                var containerProperties = new ContainerProperties("Person", "/Name")
                {
                    IndexingPolicy = indexingPolicy
                };
                var sampleResponse = await sampleDatabase.CreateContainerIfNotExistsAsync(containerProperties, 10000);
                var customContainer = sampleResponse.Container;
                await Console.Out.WriteLineAsync($"Sample Container Id:\t{customContainer.Id}");

                var createPersonResponse = await customContainer.CreateItemAsync<Person>(GetPerson(), new PartitionKey(GetPerson().Name));
                await Console.Out.WriteLineAsync($"Created person with Id:\t{createPersonResponse.Resource.Id}. Consuming total of \t{createPersonResponse.RequestCharge} RUs");
            }
        }

        private static Person GetPerson()
        {
            return new Person
            {
                BirthDate = DateTime.Now.AddYears(30),
                Id = "10.Thiago",
                Name = "Thiago",
                LastName = "Araujo",
                Vehicle = new Vehicle
                {
                    Id = 2,
                    Make = "Audi",
                    Model = "TT",
                    Year = 2020
                },
                Address = new Address
                {
                    Id = 12,
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
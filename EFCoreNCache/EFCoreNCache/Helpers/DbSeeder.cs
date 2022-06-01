using EFCoreNCache.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreNCache.Helpers
{
    public class DbSeeder
    {
        private Random Random { get; set; }
        private int StartingStoreId { get; set; }
        private int StartingConsumerId { get; set; }
        private int StartingProductId { get; set; }
        private readonly SampleDbContext sampleDbContext;

        public DbSeeder(SampleDbContext sampleDbContext)
        {
            this.sampleDbContext = sampleDbContext;
            this.Random = new Random();
        }
        public void RunSeed(int consumersQtt, int storesQtt, int productsQtt, int productsByConsumersQtt)
        {
            Console.WriteLine("Starting seed.");

            var consumers = NewConsumers(consumersQtt);
            var stores = NewStores(storesQtt);
            var products = NewProducts(productsQtt);

            sampleDbContext.Consumers.AddRange(consumers);
            sampleDbContext.Stores.AddRange(stores);
            sampleDbContext.Products.AddRange(products);

            sampleDbContext.SaveChanges();
            Console.WriteLine("Consumers, stores and products saved.");

            this.StartingConsumerId = sampleDbContext.Consumers.Count() - consumersQtt;
            this.StartingProductId = sampleDbContext.Products.Count() - productsQtt;
            this.StartingStoreId = sampleDbContext.Stores.Count() - storesQtt;

            consumers = AssignStoresToConsumers(consumers, stores);

            sampleDbContext.Consumers.UpdateRange(consumers);
            sampleDbContext.SaveChanges();
            Console.WriteLine("Consumers updated.");

            products = AssignStoresToProducts(products, stores);

            sampleDbContext.Products.UpdateRange(products);
            sampleDbContext.SaveChanges();
            Console.WriteLine("Products updated.");

            sampleDbContext.Transactions.AddRange(NewTransactions(productsByConsumersQtt,
                consumers.Select(x => x.Id).ToList(), products.Select(x => x.Id).ToList()));
            sampleDbContext.SaveChanges();
            Console.WriteLine("Transactions saved.");
        }

        private List<Consumer> AssignStoresToConsumers(List<Consumer> consumers, List<Store> stores)
        {
            consumers.ForEach(x => x.FavouriteStoreId = stores.OrderBy(x => Guid.NewGuid()).Take(1).First().Id);

            return consumers;
        }
        private List<Product> AssignStoresToProducts(List<Product> products, List<Store> stores)
        {
            products.ForEach(x => x.StoreId = stores.OrderBy(x => Guid.NewGuid()).Take(1).First().Id);

            return products;
        }

        private List<Consumer> NewConsumers(int quantity)
        {
            var result = new List<Consumer>();
            for (int i = 0; i < quantity; i++)
            {
                result.Add(NewConsumer());
            }

            return result;
        }
        private List<Product> NewProducts(int quantity)
        {
            var result = new List<Product>();
            for (int i = 0; i < quantity; i++)
            {
                result.Add(NewProduct());
            }

            return result;
        }
        private List<Store> NewStores(int quantity)
        {
            var result = new List<Store>();
            for (int i = 0; i < quantity; i++)
            {
                result.Add(NewStore());
            }

            return result;
        }
        private List<Transaction> NewTransactions(int quantity, List<int> consumerId, List<int> productId)
        {
            var result = new List<Transaction>();

            for (int i = 0; i < quantity; i++)
            {
                consumerId.ForEach(x =>
                {
                    result.Add(new Transaction { ConsumerId = x, ProductId = Random.Next(productId.Min(), productId.Max()) });
                    var J = 1000;
                if (J == 1000)
                {
                    int a = 1;
                    sampleDbContext.Transactions.AddRange(result);
                    sampleDbContext.SaveChanges();
                    result = new List<Transaction>();
                    }
                });
            }

            return result;
        }

        private Consumer NewConsumer()
        {
            return new Consumer
            {
                Name = GenerateName(Random.Next(5, 9)) + " " + GenerateName(Random.Next(5, 9))
            };
        }
        private Product NewProduct()
        {
            return new Product
            {
                Name = GenerateName(Random.Next(4, 25)),
                Price = Random.Next(0, 9999)
            };
        }
        private Store NewStore()
        {
            return new Store
            {
                Location = string.Format("Street {0} {1}. Number {2}", GenerateName(Random.Next(3, 8)), GenerateName(Random.Next(3, 8)), Random.Next(3, 8)),
                Name = GenerateName(Random.Next(3, 8))
            };
        }
        private Transaction NewTransaction(int consumerId, int productId)
        {
            return new Transaction { ProductId = productId, ConsumerId = consumerId };
        }

        private string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2;
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;


        }
    }
}

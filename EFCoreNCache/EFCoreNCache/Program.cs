using Alachisoft.NCache.EntityFrameworkCore;
using EFCoreNCache.Helpers;
using EFCoreNCache.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;



namespace EFCoreNCache
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var context = new SampleDbContext())
            {
                var cachedContext = new NCacheExtensions(context);

                Console.WriteLine("start LoadAllConsumersIntoCache " + DateTime.Now.ToString("HH:mm:ss.f"));
                var loadInCache = cachedContext.LoadAllConsumersIntoCache(new CachingOptions { StoreAs = StoreAs.Collection, QueryIdentifier = "Sample QueryIdentifier" });
                Console.WriteLine("finish LoadAllConsumersIntoCache" + DateTime.Now.ToString("HH:mm:ss.f"));

                Console.WriteLine("start GetAllConsumersFromCache " + DateTime.Now.ToString("HH:mm:ss.f"));
                var getFromCache = cachedContext.GetAllConsumersFromCache(new CachingOptions { Priority = Alachisoft.NCache.Runtime.CacheItemPriority.Default });
                Console.WriteLine("finish GetAllConsumersFromCache " + DateTime.Now.ToString("HH:mm:ss.f"));

                Console.WriteLine("start load from DBContext " + DateTime.Now.ToString("HH:mm:ss.f"));
                var getFromDb = context.Consumers.Include(x => x.Transactions).ThenInclude(x => x.Product);
                Console.WriteLine("finishg load from DBContext " + DateTime.Now.ToString("HH:mm:ss.f"));

                var cachedEntity = cachedContext.AddSingleEntity<Consumer>(getFromDb.FirstOrDefault());
                Console.WriteLine("cache key: " + cachedEntity);

                cachedContext.RemoveSingleEntity(cachedEntity);
                cachedContext.RemoveByQueryIdentifier("Sample QueryIdentifier");

            }
        }
    }
}

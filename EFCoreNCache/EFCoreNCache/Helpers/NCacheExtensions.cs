using Alachisoft.NCache.Client;
using Alachisoft.NCache.EntityFrameworkCore;
using Alachisoft.NCache.Runtime.Caching;
using EFCoreNCache.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreNCache.Helpers
{
    public class NCacheExtensions
    {
        private SampleDbContext Database { get; set; }
        private CachingOptions CachingOptions { get; set; }
        private Cache Cache { get; set; }

        public NCacheExtensions(SampleDbContext database)
        {
            this.Database = database;
            this.CachingOptions = new CachingOptions
            {
                QueryIdentifier = "Sample QueryIdentifier",
                Priority = Alachisoft.NCache.Runtime.CacheItemPriority.Default,
                CreateDbDependency = false,
                StoreAs = StoreAs.Collection
            };

            Cache = database.GetCache();
        }

        public string AddSingleEntity<T>(T entity)
        {
            Cache.Insert(entity, out string cacheKey, this.CachingOptions);
            return cacheKey;
        }
        public void RemoveSingleEntity<T>(T entity)
        {
            Cache.Remove(entity);
        }
        public void RemoveSingleEntity(string cacheKey)
        {
            Cache.Remove(cacheKey);
        }
        public void RemoveByQueryIdentifier(string queryIdentifier)
        {
            var tag = new Tag(queryIdentifier);
            Cache.RemoveByQueryIdentifier(tag);
        }

        public IEnumerable<Consumer> GetAllConsumersFromCache(CachingOptions cachingOptions)
        {
            return Database.Consumers.Include(x => x.Transactions).ThenInclude(x => x.Product).FromCache(cachingOptions);
        }
        public async Task<IEnumerable<Consumer>> GetAllConsumersFromCacheAsync(CachingOptions cachingOptions)
        {
            return await Database.Consumers.Include(x => x.Transactions).ThenInclude(x => x.Product).FromCacheAsync(cachingOptions);
        }
        public IEnumerable<Consumer> LoadAllConsumersIntoCache(CachingOptions cachingOptions)
        {
            return Database.Consumers.Include(x => x.Transactions).ThenInclude(x => x.Product).LoadIntoCache(cachingOptions);
        }
        public async Task<IEnumerable<Consumer>> LoadAllConsumersIntoCacheAsync(CachingOptions cachingOptions)
        {
            return await Database.Consumers.Include(x => x.Transactions).ThenInclude(x => x.Product).LoadIntoCacheAsync(cachingOptions);
        }
        public IEnumerable<Consumer> GetAllConsumersFromCacheOnly(CachingOptions cachingOptions)
        {
            return Database.Consumers.FromCacheOnly();
        }
    }
}

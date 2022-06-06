using Alachisoft.NCache.Client;
using Alachisoft.NCache.EntityFrameworkCore;
using Alachisoft.NCache.Web.Caching;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreNCache.Models
{
    public class SampleDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // configure cache with SQLServer DependencyType and CacheInitParams
            CacheConnectionOptions initParams = new CacheConnectionOptions();
            initParams.RetryInterval = new TimeSpan(0, 0, 5);
            initParams.ConnectionRetries = 2;
            initParams.ConnectionTimeout = new TimeSpan(0, 0, 5);
            initParams.AppName = "appName";
            initParams.CommandRetries = 2;
            initParams.CommandRetryInterval = new TimeSpan(0, 0, 5);
            initParams.Mode = IsolationLevel.Default;

            NCacheConfiguration.Configure("democache", DependencyType.SqlServer, initParams);
            
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HAS2E;Initial Catalog=sampleDatabase;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .HasMany(x => x.AvailableProducts)
                .WithOne(x => x.Store)
                .HasForeignKey(x => x.StoreId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Store>()
                .HasMany(x => x.RegularConsumers)
                .WithOne(x => x.FavouriteStore)
                .HasForeignKey(x => x.FavouriteStoreId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transaction>()
                .HasOne(x => x.Consumer)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.ConsumerId)
                .IsRequired(false);

            modelBuilder.Entity<Transaction>()
                .HasOne(x => x.Product)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.ProductId)
                .IsRequired(false);
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}

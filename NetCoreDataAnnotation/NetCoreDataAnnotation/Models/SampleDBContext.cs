using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDataAnnotation.Models
{
    public class SampleDBContext : DbContext
    {
        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer( @"Data Source = DESKTOP-PKIN6P4; Initial Catalog = SampleDataAnnotation; Integrated Security = true" );
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder ) //Fluent API mode
        {
            //modelBuilder.Entity<Post>()
            //.HasOne( p => p.Blog )
            //.WithMany( b => b.Posts );

            // modelBuilder.Entity<Blog>()
            //.HasMany( b => b.Posts )
            //.WithOne();

            //     modelBuilder.Entity<Post>()
            //.HasOne( p => p.Blog )
            //.WithMany( b => b.Posts )
            //.HasForeignKey( p => p.BlogForeignKey );

            //     modelBuilder.Entity<RecordOfSale>()
            //.HasOne( s => s.Car )
            //.WithMany( c => c.SaleHistory )
            //.HasForeignKey( s => s.CarLicensePlate )
            //.HasPrincipalKey( c => c.LicensePlate );
            //------------------------------------------------------------XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX--------------------------------------------------------------
            //            Many - to - many
            //Many - to - many relationships without an entity class to represent the join table are not yet supported.However, you can represent a many-to-many relationship by including an entity class for the join table and mapping two separate one-to-many relationships.

            //   C#

            //Copy
            //class MyContext : DbContext
            //        {
            //            public DbSet<Post> Posts { get; set; }
            //            public DbSet<Tag> Tags { get; set; }

            //            protected override void OnModelCreating( ModelBuilder modelBuilder )
            //            {
            //                modelBuilder.Entity<PostTag>()
            //                    .HasKey( t => new { t.PostId, t.TagId } );

            //                modelBuilder.Entity<PostTag>()
            //                    .HasOne( pt => pt.Post )
            //                    .WithMany( p => p.PostTags )
            //                    .HasForeignKey( pt => pt.PostId );

            //                modelBuilder.Entity<PostTag>()
            //                    .HasOne( pt => pt.Tag )
            //                    .WithMany( t => t.PostTags )
            //                    .HasForeignKey( pt => pt.TagId );
            //            }
            //        }

            //        public class Post
            //        {
            //            public int PostId { get; set; }
            //            public string Title { get; set; }
            //            public string Content { get; set; }

            //            public List<PostTag> PostTags { get; set; }
            //        }

            //        public class Tag
            //        {
            //            public string TagId { get; set; }

            //            public List<PostTag> PostTags { get; set; }
            //        }

            //        public class PostTag
            //        {
            //            public int PostId { get; set; }
            //            public Post Post { get; set; }

            //            public string TagId { get; set; }
            //            public Tag Tag { get; set; }
            //        }
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<TripManager> TripManager { get; set; }
    }
}
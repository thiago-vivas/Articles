using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SimulateCodeFirst
{
    public class SampleContextFactory : IDbContextFactory<SampleContext>
    {
        public SampleContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SampleContext>();
            optionsBuilder.UseSqlServer("Data Source=YOUR DATA SOURCE;");

            return new SampleContext(optionsBuilder.Options);
        }
    }
}

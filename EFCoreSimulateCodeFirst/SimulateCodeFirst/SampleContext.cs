using Microsoft.EntityFrameworkCore;
using SimulateCodeFirst.Models;

namespace SimulateCodeFirst
{
  public  class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options) : base(options)
        {

        }
        public DbSet<ModelSample> SampleClass { get; set; }
    }
}

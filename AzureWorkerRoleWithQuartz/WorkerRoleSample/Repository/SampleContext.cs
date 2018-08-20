using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerRoleSample.Repository
{
    public class SampleContext : DbContext
    {
        public SampleContext() : base( "name =DBContext" )
        {
        }

        public DbSet<LogSample> LogSample { get; set; }
    }
}
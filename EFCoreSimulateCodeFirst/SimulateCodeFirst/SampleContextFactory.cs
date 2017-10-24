using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulateCodeFirst
{
    public class SampleContextFactory : IDbContextFactory<SampleContext>
    {
        public SampleContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SampleContext>();
            optionsBuilder.UseSqlServer("Data Source=DESENV41;Initial Catalog=DB_Sample;Integrated Security=True;");

            return new SampleContext(optionsBuilder.Options);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SimulateCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Text;

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

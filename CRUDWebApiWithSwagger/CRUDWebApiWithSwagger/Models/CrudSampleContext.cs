using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithSwagger.Models;

namespace CRUDWebApiWithSwagger.Models
{
    public class CrudSampleContext : DbContext
    {
        public CrudSampleContext(DbContextOptions<CrudSampleContext> options) : base(options)
        {
        }

        public DbSet<ValueSamples> ValueSamples { get; set; }
    }
}

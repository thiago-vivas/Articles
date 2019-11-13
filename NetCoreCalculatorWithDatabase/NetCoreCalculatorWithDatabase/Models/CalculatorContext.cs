using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using NetCoreCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCalculatorWithDatabase.Models
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options)
        { }
        public DbSet<CompoundInterestModel> CompoundInterestModels { get; set; }
        public DbSet<Operation> Operations { get; set; }
    }
}



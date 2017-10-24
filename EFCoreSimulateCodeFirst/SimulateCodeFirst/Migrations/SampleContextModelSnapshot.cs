using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SimulateCodeFirst;

namespace SimulateCodeFirst.Migrations
{
    [DbContext(typeof(SampleContext))]
    partial class SampleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimulateCodeFirst.Models.ModelSample", b =>
                {
                    b.Property<int>("IdModelSample")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescriptionModelSample");

                    b.HasKey("IdModelSample");

                    b.ToTable("SampleClass");
                });
        }
    }
}

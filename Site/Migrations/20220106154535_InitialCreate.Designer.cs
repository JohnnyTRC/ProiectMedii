// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Site.Data;

namespace Site.Migrations
{
    [DbContext(typeof(SiteContext))]
    [Migration("20220106154535_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Site.Models.SiteOrder", b =>
                {
                    b.Property<int>("ComandaSiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantitate")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataComanda")
                        .HasColumnType("datetime2");

                    b.HasKey("ComandaSiteId");

                    b.ToTable("SiteOrder");
                });
#pragma warning restore 612, 618
        }
    }
}

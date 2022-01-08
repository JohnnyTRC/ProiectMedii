﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Site.Data;

namespace Site.Migrations
{
    [DbContext(typeof(SiteContext))]
    partial class SiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Site.Models.Custom", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NrTelefon")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumeClient")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PrenumeClient")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClientId");

                    b.ToTable("Custom");
                });

            modelBuilder.Entity("Site.Models.SiteOrder", b =>
                {
                    b.Property<int>("ComandaSiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantitate")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataComanda")
                        .HasColumnType("datetime2");

                    b.HasKey("ComandaSiteId");

                    b.HasIndex("CustomClientId");

                    b.ToTable("SiteOrder");
                });

            modelBuilder.Entity("Site.Models.SiteOrder", b =>
                {
                    b.HasOne("Site.Models.Custom", "Custom")
                        .WithMany("SiteOrders")
                        .HasForeignKey("CustomClientId");

                    b.Navigation("Custom");
                });

            modelBuilder.Entity("Site.Models.Custom", b =>
                {
                    b.Navigation("SiteOrders");
                });
#pragma warning restore 612, 618
        }
    }
}

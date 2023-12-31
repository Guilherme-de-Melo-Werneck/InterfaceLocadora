﻿// <auto-generated />
using Locadora.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Locadora.Migrations
{
    [DbContext(typeof(LocadoraContext))]
    partial class LocadoraContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Locadora.Models.Filme", b =>
                {
                    b.Property<long>("FilmeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FilmeID"));

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("Sobre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FilmeID");

                    b.ToTable("Filmes");
                });
#pragma warning restore 612, 618
        }
    }
}

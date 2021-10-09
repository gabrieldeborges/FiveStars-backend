﻿// <auto-generated />
using FIVESTARS.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FIVESTARS.Infra.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20211009051518_tabelClient2")]
    partial class tabelClient2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("FIVESTARS.Domain.Entities.Bedroom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BED_TYPE")
                        .HasColumnType("longtext");

                    b.Property<int>("DOOR")
                        .HasColumnType("int");

                    b.Property<int>("FLOOR")
                        .HasColumnType("int");

                    b.Property<string>("MORE_INFORMATION")
                        .HasColumnType("longtext");

                    b.Property<int>("QUANTITY_BATHROOM")
                        .HasColumnType("int");

                    b.Property<int>("QUANTITY_BEDS")
                        .HasColumnType("int");

                    b.Property<int>("STATUS")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("BEDROOM");
                });

            modelBuilder.Entity("FIVESTARS.Domain.Entities.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CEP")
                        .HasColumnType("longtext");

                    b.Property<string>("CPF")
                        .HasColumnType("longtext");

                    b.Property<string>("NOME")
                        .HasColumnType("longtext");

                    b.Property<int>("STATUS")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("CLIENT");
                });

            modelBuilder.Entity("FIVESTARS.Domain.Entities.Teste", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NOME")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("TABELA_TESTE");
                });
#pragma warning restore 612, 618
        }
    }
}
using FIVESTARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIVESTARS.Infra.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }
        public DbSet<Teste> teste { get; set; }
        public DbSet<Bedroom> Bedroom { get; set; }
        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teste>().ToTable("TABELA_TESTE").HasKey(x => x.ID);
            modelBuilder.Entity<Client>().ToTable("CLIENT").HasKey(x => x.ID);

            modelBuilder.Entity<Bedroom>().ToTable("BEDROOM").HasKey(x => x.ID);

            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Teste>().HasOne(x => x.TABELA_TESTE)
            //       .WithMany(ctn => ctn.TABELA_TESTE)
            //       .HasForeignKey(fk => fk.TABELA_TESTE);
        }


    }
}
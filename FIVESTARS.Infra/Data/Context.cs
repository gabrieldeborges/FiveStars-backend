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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teste>().ToTable("TABELA_TESTE").HasKey(x => x.ID);
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Teste>().HasOne(x => x.FOR_ITEM_COMPRA)
            //       .WithMany(ctn => ctn.FOR_ITEM_CONTRATO)
            //       .HasForeignKey(fk => fk.ID_ITEM_COMPRA);
        }

      
    }
}
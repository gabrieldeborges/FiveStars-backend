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
            modelBuilder.Entity<Reservation>().ToTable("RESERVATION").HasKey(x => x.ID);
            modelBuilder.Entity<Bedroom>().ToTable("BEDROOM").HasKey(x => x.ID);

            modelBuilder.Entity<Reservation>().HasOne(x => x.BEDROOM)
                   .WithMany(ctn => ctn.RESERVATION)
                   .HasForeignKey(fk => fk.ID_BEDROOM);

            modelBuilder.Entity<Reservation>().HasOne(x => x.CLIENT)
                   .WithMany(ctn => ctn.RESERVATION)
                   .HasForeignKey(fk => fk.ID_CLIENT);

            base.OnModelCreating(modelBuilder);
        }


    }
}
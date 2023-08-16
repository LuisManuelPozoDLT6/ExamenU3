using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenU3.Models;
using Microsoft.EntityFrameworkCore;
namespace ExamenU3
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) :base(options){

        }

                public DbSet<Categorias>? Categorias {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>().HasData(
                new Categorias()
                {
                    Id = 1,
                    Nombre = "Test",
                    FechaCreacion = new DateTime(),
                    FechaActualizacion = new DateTime()
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
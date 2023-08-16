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
                public DbSet<Productos>? Productoss{get; set;}

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

            modelBuilder.Entity<Productos>().HasData(
                new Productos()
                {
                    Id = 1,
                    Nombre = "!Iphone 14 Pro Max",
                    Descripcion = "Telefono de gama alta con 562 GBS",
                    Precio = 33000,
                    Cantidad = 500
                    
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
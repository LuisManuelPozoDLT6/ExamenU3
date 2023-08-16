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
                public DbSet<Pedidos>? Pedidos {get; set;}

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
            modelBuilder.Entity<Pedidos>().HasData(
                new Pedidos()
                {
                    Id = 1,
                    FechaSolicitud = new DateTime(),
                    FechaEntrega = new DateTime(),
                    Direccion = "Calle 48 Norte #32",
                    TotalPagar = 2500.00,
                    MetodoPago = "Tarjeta"
                }
            );
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
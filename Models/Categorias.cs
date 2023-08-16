using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenU3.Models
{
    public class Categorias
    {
        public int Id { get; set;}
        public string? Nombre { get; set;}
        public DateTime FechaCreacion { get; set;}
        public DateTime FechaActualizacion { get; set;}
    }
}
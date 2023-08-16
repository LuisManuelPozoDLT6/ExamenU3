using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenU3.Models
{
    public class Pedidos
    {
        public int Id { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string? Direccion { get; set; }
        public double? TotalPagar { get; set; }
        public string? MetodoPago { get; set; }
    }
}
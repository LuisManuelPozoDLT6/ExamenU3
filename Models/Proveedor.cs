using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenU3.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string? NombreEmpresa { get; set; }
        public string? NombreRepartidor { get; set; }
        public string? CorreoElectronico { get; set; }
        public int Telefono { get; set; }
    }
}
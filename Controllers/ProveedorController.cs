
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ExamenU3.Models;


namespace ExamenU3
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public ProveedorController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listProveedor = await _context.Proveedor.ToListAsync();
            if (listProveedor == null || listProveedor.Count == 0)
            {
                return NoContent();
            }
            return Ok(listProveedor);
        }

        [HttpGet("Show/{id}")]
        public async Task<IActionResult> Show(int id)
        {
            var proveedor = await _context.Proveedor.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return Ok(proveedor);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Proveedor proveedor)
        {
            if (proveedor == null)
            {
                return HttpStatusCode.BadRequest; //code 400
            }
            _context.Add(proveedor);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created; // code 201
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Proveedor proveedor)
        {
            if (proveedor == null || proveedor.Id != id)
            {
                return BadRequest();//400
            }
            var entity = await _context.Proveedor.FindAsync(id);
            if (entity == null)
            {
                return BadRequest();//404
            }
            entity.NombreEmpresa = proveedor.NombreEmpresa;
            entity.NombreRepartidor = proveedor.NombreRepartidor;
            entity.CorreoElectronico = proveedor.CorreoElectronico;
            entity.Telefono = proveedor.Telefono;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("Destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var proveedor = await _context.Proveedor.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            _context.Proveedor.Remove(proveedor);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }

}


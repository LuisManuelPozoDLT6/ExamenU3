using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenU3.Models;

namespace ExamenU3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public PedidosController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listPedidos = await _context.Pedidos.ToListAsync();
            if (listPedidos == null || listPedidos.Count == 0)
            {
                return NoContent();
            }
            return Ok(listPedidos);
        }

        [HttpGet("Show/{id}")]
        public async Task<IActionResult> Show(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost("Store")]
        public async Task<IActionResult> Store([FromBody] Pedidos pedido)
        {
            if (pedido == null)
            {
                return BadRequest(); // code 400
            }
            _context.Add(pedido);
            await _context.SaveChangesAsync();
            return StatusCode((int)HttpStatusCode.Created); // code 201
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Pedidos pedido)
        {
            if (pedido == null || pedido.Id != id)
            {
                return BadRequest(); // 400
            }
            var entity = await _context.Pedidos.FindAsync(id);
            if (entity == null)
            {
                return NotFound(); // 404
            }
            entity.FechaSolicitud = pedido.FechaSolicitud;
            entity.FechaEntrega = pedido.FechaEntrega;
            entity.Direccion = pedido.Direccion;
            entity.TotalPagar = pedido.TotalPagar;
            entity.MetodoPago = pedido.MetodoPago;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("Destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

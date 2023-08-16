using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ExamenU3.Models;

namespace ExamenU3.Controllers{
    [Route("api/[controller]")]
    [ApiController]

    public class ClienteController : ControllerBase{
        private readonly AplicationDbContext _context;

        public ClienteController(AplicationDbContext context){
            _context = context;
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Clientes cliente)
        {
            if (cliente == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listClientes = await _context.Clientes.ToListAsync();
            if (listClientes == null || listClientes.Count == 0)
            {
                return NoContent();
            }
            return Ok(listClientes);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(/*int id, */[FromBody] Clientes cliente)
        {
            if (cliente == null /*|| comment.Id != id*/)
            {
                return BadRequest();
            }
            var entity = await _context.Clientes.FindAsync(cliente.Id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Nombre = cliente.Nombre;
            entity.Apellidos = cliente.Apellidos;
            entity.Rfc = cliente.Rfc;
            entity.Correo = cliente.Correo;
            entity.Telefono = cliente.Telefono;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var comment = await _context.Clientes.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(comment);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ExamenU3.Models;
using ExamenU3;
namespace ExamenU3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public ProductosController(AplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listaProductos = await _context.Productoss.ToListAsync();
            if (listaProductos == null || listaProductos.Count == 0)
            {
                return NoContent();

            }
            return Ok(listaProductos);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Productos producto)
        {
            if (producto == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(producto);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var comment = await _context.Productoss.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var producto = await _context.Productoss.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }
            _context.Productoss.Remove(producto);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id,[FromBody] Productos producto){
            if(producto==null || producto.Id !=id){
                return BadRequest();
            }
            var entity = await _context.Productoss.FindAsync(id);
            if(entity==null){
                return NotFound();
            }
            entity.Nombre = producto.Nombre;
            entity.Descripcion = producto.Descripcion;
            entity.Precio = producto.Precio;
            entity.Cantidad = producto.Cantidad;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
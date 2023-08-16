using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenU3.Models;

namespace ExamenU3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public CategoriaController(AplicationDbContext context) {
            _context = context;
        }
        [HttpGet("All")] // Se pudo haber escrito asi [HttpGet("Index")] 
        public async Task<IActionResult> Index(){
            var listaCategorias = await _context.Categorias.ToListAsync();

            if (listaCategorias == null || listaCategorias.Count == 0)
            {
                return NoContent();
            }
            return Ok(listaCategorias);
        }

        [HttpGet("FindById")]
        public async Task<IActionResult> Show(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost("Crear")]
        public async Task<HttpStatusCode> Store([FromBody] Categorias categoria)
        {
            if (categoria == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Destroy(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Update([FromBody] Categorias categoria)
        {
            if(categoria == null ){
                return BadRequest();//400
            }
            var entity = await _context.Categorias.FindAsync(categoria.Id);
            if(entity == null){
                return BadRequest();//404
            }
            entity.Nombre = categoria.Nombre;
            entity.FechaCreacion = categoria.FechaCreacion;
            entity.FechaActualizacion = categoria.FechaActualizacion;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
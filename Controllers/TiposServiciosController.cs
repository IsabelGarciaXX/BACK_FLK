using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BACK_FLK.Models;

namespace BACK_FLK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposServiciosController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public TiposServiciosController(BdFlkContext context)
        {
            _context = context;
        }

        // GET: api/TiposServicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposServicio>>> GetTiposServicios()
        {
            return await _context.TiposServicios.ToListAsync();
        }

        // GET: api/TiposServicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiposServicio>> GetTiposServicio(int id)
        {
            var tiposServicio = await _context.TiposServicios.FindAsync(id);

            if (tiposServicio == null)
            {
                return NotFound();
            }

            return tiposServicio;
        }

        // POST: api/TiposServicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TiposServicio>> PostTiposServicio(TiposServicio tiposServicio)
        {
            _context.TiposServicios.Add(tiposServicio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TiposServicioExists(tiposServicio.PkTiposServicio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTiposServicio", new { id = tiposServicio.PkTiposServicio }, tiposServicio);
        }

        // DELETE: api/TiposServicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposServicio(int id)
        {
            var tiposServicio = await _context.TiposServicios.FindAsync(id);
            if (tiposServicio == null)
            {
                return NotFound();
            }

            _context.TiposServicios.Remove(tiposServicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposServicioExists(int id)
        {
            return _context.TiposServicios.Any(e => e.PkTiposServicio == id);
        }
    }
}

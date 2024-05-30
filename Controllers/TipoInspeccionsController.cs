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
    public class TipoInspeccionsController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public TipoInspeccionsController(BdFlkContext context)
        {
            _context = context;
        }

        // GET: api/TipoInspeccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoInspeccion>>> GetTipoInspeccions()
        {
            return await _context.TipoInspeccions.ToListAsync();
        }

        // GET: api/TipoInspeccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoInspeccion>> GetTipoInspeccion(int id)
        {
            var tipoInspeccion = await _context.TipoInspeccions.FindAsync(id);

            if (tipoInspeccion == null)
            {
                return NotFound();
            }

            return tipoInspeccion;
        }

        // PUT: api/TipoInspeccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoInspeccion(int id, TipoInspeccion tipoInspeccion)
        {
            if (id != tipoInspeccion.PkTipoInspeccion)
            {
                return BadRequest();
            }

            _context.Entry(tipoInspeccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoInspeccionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TipoInspeccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoInspeccion>> PostTipoInspeccion(TipoInspeccion tipoInspeccion)
        {
            _context.TipoInspeccions.Add(tipoInspeccion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoInspeccionExists(tipoInspeccion.PkTipoInspeccion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoInspeccion", new { id = tipoInspeccion.PkTipoInspeccion }, tipoInspeccion);
        }

        // DELETE: api/TipoInspeccions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoInspeccion(int id)
        {
            var tipoInspeccion = await _context.TipoInspeccions.FindAsync(id);
            if (tipoInspeccion == null)
            {
                return NotFound();
            }

            _context.TipoInspeccions.Remove(tipoInspeccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoInspeccionExists(int id)
        {
            return _context.TipoInspeccions.Any(e => e.PkTipoInspeccion == id);
        }
    }
}

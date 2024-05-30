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
    public class TipoDocumentoIdentidadsController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public TipoDocumentoIdentidadsController(BdFlkContext context)
        {
            _context = context;
        }

        // GET: api/TipoDocumentoIdentidads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDocumentoIdentidad>>> GetTipoDocumentoIdentidads()
        {
            return await _context.TipoDocumentoIdentidads.ToListAsync();
        }

        // GET: api/TipoDocumentoIdentidads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDocumentoIdentidad>> GetTipoDocumentoIdentidad(int id)
        {
            var tipoDocumentoIdentidad = await _context.TipoDocumentoIdentidads.FindAsync(id);

            if (tipoDocumentoIdentidad == null)
            {
                return NotFound();
            }

            return tipoDocumentoIdentidad;
        }

        // PUT: api/TipoDocumentoIdentidads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDocumentoIdentidad(int id, TipoDocumentoIdentidad tipoDocumentoIdentidad)
        {
            if (id != tipoDocumentoIdentidad.PkTipoDocumentoIdentidad)
            {
                return BadRequest();
            }

            _context.Entry(tipoDocumentoIdentidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDocumentoIdentidadExists(id))
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

        // POST: api/TipoDocumentoIdentidads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoDocumentoIdentidad>> PostTipoDocumentoIdentidad(TipoDocumentoIdentidad tipoDocumentoIdentidad)
        {
            _context.TipoDocumentoIdentidads.Add(tipoDocumentoIdentidad);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoDocumentoIdentidadExists(tipoDocumentoIdentidad.PkTipoDocumentoIdentidad))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoDocumentoIdentidad", new { id = tipoDocumentoIdentidad.PkTipoDocumentoIdentidad }, tipoDocumentoIdentidad);
        }

        // DELETE: api/TipoDocumentoIdentidads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDocumentoIdentidad(int id)
        {
            var tipoDocumentoIdentidad = await _context.TipoDocumentoIdentidads.FindAsync(id);
            if (tipoDocumentoIdentidad == null)
            {
                return NotFound();
            }

            _context.TipoDocumentoIdentidads.Remove(tipoDocumentoIdentidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoDocumentoIdentidadExists(int id)
        {
            return _context.TipoDocumentoIdentidads.Any(e => e.PkTipoDocumentoIdentidad == id);
        }
    }
}

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
    public class InspeccionesController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public InspeccionesController(BdFlkContext context)
        {
            _context = context;
        }

        // GET: api/Inspecciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inspeccione>>> GetInspecciones()
        {
            return await _context.Inspecciones.ToListAsync();
        }

        // GET: api/Inspecciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inspeccione>> GetInspeccione(int id)
        {
            var inspeccione = await _context.Inspecciones.FindAsync(id);

            if (inspeccione == null)
            {
                return NotFound();
            }

            return inspeccione;
        }

        // PUT: api/Inspecciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspeccione(int id, Inspeccione inspeccione)
        {
            if (id != inspeccione.PkInspeccion)
            {
                return BadRequest();
            }

            _context.Entry(inspeccione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspeccioneExists(id))
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

        // POST: api/Inspecciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inspeccione>> PostInspeccione(Inspeccione inspeccione)
        {
            _context.Inspecciones.Add(inspeccione);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InspeccioneExists(inspeccione.PkInspeccion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInspeccione", new { id = inspeccione.PkInspeccion }, inspeccione);
        }

        // DELETE: api/Inspecciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspeccione(int id)
        {
            var inspeccione = await _context.Inspecciones.FindAsync(id);
            if (inspeccione == null)
            {
                return NotFound();
            }

            _context.Inspecciones.Remove(inspeccione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InspeccioneExists(int id)
        {
            return _context.Inspecciones.Any(e => e.PkInspeccion == id);
        }
    }
}

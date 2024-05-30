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
    public class DocenteDisponiblesController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public DocenteDisponiblesController(BdFlkContext context)
        {
            _context = context;
        }

        // GET: api/DocenteDisponibles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocenteDisponible>>> GetDocenteDisponibles()
        {
            return await _context.DocenteDisponibles.ToListAsync();
        }

        // GET: api/DocenteDisponibles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocenteDisponible>> GetDocenteDisponible(int id)
        {
            var docenteDisponible = await _context.DocenteDisponibles.FindAsync(id);

            if (docenteDisponible == null)
            {
                return NotFound();
            }

            return docenteDisponible;
        }

        // PUT: api/DocenteDisponibles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocenteDisponible(int id, DocenteDisponible docenteDisponible)
        {
            if (id != docenteDisponible.PkDocenteDisponibles)
            {
                return BadRequest();
            }

            _context.Entry(docenteDisponible).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocenteDisponibleExists(id))
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

        // POST: api/DocenteDisponibles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DocenteDisponible>> PostDocenteDisponible(DocenteDisponible docenteDisponible)
        {
            _context.DocenteDisponibles.Add(docenteDisponible);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DocenteDisponibleExists(docenteDisponible.PkDocenteDisponibles))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDocenteDisponible", new { id = docenteDisponible.PkDocenteDisponibles }, docenteDisponible);
        }

        // DELETE: api/DocenteDisponibles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocenteDisponible(int id)
        {
            var docenteDisponible = await _context.DocenteDisponibles.FindAsync(id);
            if (docenteDisponible == null)
            {
                return NotFound();
            }

            _context.DocenteDisponibles.Remove(docenteDisponible);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocenteDisponibleExists(int id)
        {
            return _context.DocenteDisponibles.Any(e => e.PkDocenteDisponibles == id);
        }
    }
}

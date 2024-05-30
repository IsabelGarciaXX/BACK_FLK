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
    public class InspectoresDisponiblesController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public InspectoresDisponiblesController(BdFlkContext context)
        {
            _context = context;
        }

        // GET: api/InspectoresDisponibles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectoresDisponible>>> GetInspectoresDisponibles()
        {
            return await _context.InspectoresDisponibles.ToListAsync();
        }

        // GET: api/InspectoresDisponibles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspectoresDisponible>> GetInspectoresDisponible(int id)
        {
            var inspectoresDisponible = await _context.InspectoresDisponibles.FindAsync(id);

            if (inspectoresDisponible == null)
            {
                return NotFound();
            }

            return inspectoresDisponible;
        }

        // PUT: api/InspectoresDisponibles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspectoresDisponible(int id, InspectoresDisponible inspectoresDisponible)
        {
            if (id != inspectoresDisponible.PkInpectoresDisponibles)
            {
                return BadRequest();
            }

            _context.Entry(inspectoresDisponible).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectoresDisponibleExists(id))
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

        // POST: api/InspectoresDisponibles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InspectoresDisponible>> PostInspectoresDisponible(InspectoresDisponible inspectoresDisponible)
        {
            _context.InspectoresDisponibles.Add(inspectoresDisponible);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InspectoresDisponibleExists(inspectoresDisponible.PkInpectoresDisponibles))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInspectoresDisponible", new { id = inspectoresDisponible.PkInpectoresDisponibles }, inspectoresDisponible);
        }

        // DELETE: api/InspectoresDisponibles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspectoresDisponible(int id)
        {
            var inspectoresDisponible = await _context.InspectoresDisponibles.FindAsync(id);
            if (inspectoresDisponible == null)
            {
                return NotFound();
            }

            _context.InspectoresDisponibles.Remove(inspectoresDisponible);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InspectoresDisponibleExists(int id)
        {
            return _context.InspectoresDisponibles.Any(e => e.PkInpectoresDisponibles == id);
        }
    }
}

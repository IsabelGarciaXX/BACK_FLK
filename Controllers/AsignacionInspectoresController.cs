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
    public class AsignacionInspectoresController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public AsignacionInspectoresController(BdFlkContext context)
        {
            _context = context;
        }

        // GET: api/AsignacionInspectores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignacionInspectore>>> GetAsignacionInspectores()
        {
            return await _context.AsignacionInspectores.ToListAsync();
        }

        // GET: api/AsignacionInspectores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignacionInspectore>> GetAsignacionInspectore(int id)
        {
            var asignacionInspectore = await _context.AsignacionInspectores.FindAsync(id);

            if (asignacionInspectore == null)
            {
                return NotFound();
            }

            return asignacionInspectore;
        }

        // PUT: api/AsignacionInspectores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignacionInspectore(int id, AsignacionInspectore asignacionInspectore)
        {
            if (id != asignacionInspectore.PkAsignacionId)
            {
                return BadRequest();
            }

            _context.Entry(asignacionInspectore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignacionInspectoreExists(id))
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

        // POST: api/AsignacionInspectores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AsignacionInspectore>> PostAsignacionInspectore(AsignacionInspectore asignacionInspectore)
        {
            _context.AsignacionInspectores.Add(asignacionInspectore);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AsignacionInspectoreExists(asignacionInspectore.PkAsignacionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAsignacionInspectore", new { id = asignacionInspectore.PkAsignacionId }, asignacionInspectore);
        }

        // DELETE: api/AsignacionInspectores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignacionInspectore(int id)
        {
            var asignacionInspectore = await _context.AsignacionInspectores.FindAsync(id);
            if (asignacionInspectore == null)
            {
                return NotFound();
            }

            _context.AsignacionInspectores.Remove(asignacionInspectore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsignacionInspectoreExists(int id)
        {
            return _context.AsignacionInspectores.Any(e => e.PkAsignacionId == id);
        }
    }
}

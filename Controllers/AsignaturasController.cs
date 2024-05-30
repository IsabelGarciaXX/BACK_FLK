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
    public class AsignaturasController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public AsignaturasController(BdFlkContext context)
        {
            _context = context;
        }

        // GET: api/Asignaturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asignatura>>> GetAsignaturas()
        {
            return await _context.Asignaturas.ToListAsync();
        }

        // GET: api/Asignaturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asignatura>> GetAsignatura(int id)
        {
            var asignatura = await _context.Asignaturas.FindAsync(id);

            if (asignatura == null)
            {
                return NotFound();
            }

            return asignatura;
        }

        // PUT: api/Asignaturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignatura(int id, Asignatura asignatura)
        {
            if (id != asignatura.PkAsignatura)
            {
                return BadRequest();
            }

            _context.Entry(asignatura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignaturaExists(id))
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

        // POST: api/Asignaturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Asignatura>> PostAsignatura(Asignatura asignatura)
        {
            _context.Asignaturas.Add(asignatura);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AsignaturaExists(asignatura.PkAsignatura))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAsignatura", new { id = asignatura.PkAsignatura }, asignatura);
        }

        // DELETE: api/Asignaturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignatura(int id)
        {
            var asignatura = await _context.Asignaturas.FindAsync(id);
            if (asignatura == null)
            {
                return NotFound();
            }

            _context.Asignaturas.Remove(asignatura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsignaturaExists(int id)
        {
            return _context.Asignaturas.Any(e => e.PkAsignatura == id);
        }
    }
}

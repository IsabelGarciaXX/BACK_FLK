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
    public class CertificadoresDisponiblesController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public CertificadoresDisponiblesController(BdFlkContext context)
        {
            _context = context;
        }

        // GET: api/CertificadoresDisponibles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificadoresDisponible>>> GetCertificadoresDisponibles()
        {
            return await _context.CertificadoresDisponibles.ToListAsync();
        }

        // GET: api/CertificadoresDisponibles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificadoresDisponible>> GetCertificadoresDisponible(int id)
        {
            var certificadoresDisponible = await _context.CertificadoresDisponibles.FindAsync(id);

            if (certificadoresDisponible == null)
            {
                return NotFound();
            }

            return certificadoresDisponible;
        }

        // PUT: api/CertificadoresDisponibles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificadoresDisponible(int id, CertificadoresDisponible certificadoresDisponible)
        {
            if (id != certificadoresDisponible.PkCertificadoresDisponibles)
            {
                return BadRequest();
            }

            _context.Entry(certificadoresDisponible).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificadoresDisponibleExists(id))
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

        // POST: api/CertificadoresDisponibles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CertificadoresDisponible>> PostCertificadoresDisponible(CertificadoresDisponible certificadoresDisponible)
        {
            _context.CertificadoresDisponibles.Add(certificadoresDisponible);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CertificadoresDisponibleExists(certificadoresDisponible.PkCertificadoresDisponibles))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCertificadoresDisponible", new { id = certificadoresDisponible.PkCertificadoresDisponibles }, certificadoresDisponible);
        }

        // DELETE: api/CertificadoresDisponibles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificadoresDisponible(int id)
        {
            var certificadoresDisponible = await _context.CertificadoresDisponibles.FindAsync(id);
            if (certificadoresDisponible == null)
            {
                return NotFound();
            }

            _context.CertificadoresDisponibles.Remove(certificadoresDisponible);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertificadoresDisponibleExists(int id)
        {
            return _context.CertificadoresDisponibles.Any(e => e.PkCertificadoresDisponibles == id);
        }
    }
}

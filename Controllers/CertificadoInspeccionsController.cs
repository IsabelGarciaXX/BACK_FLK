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
    public class CertificadoInspeccionsController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public CertificadoInspeccionsController(BdFlkContext context)
        {
            _context = context;
        }

        // GET: api/CertificadoInspeccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificadoInspeccion>>> GetCertificadoInspeccions()
        {
            return await _context.CertificadoInspeccions.ToListAsync();
        }

        // GET: api/CertificadoInspeccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificadoInspeccion>> GetCertificadoInspeccion(int id)
        {
            var certificadoInspeccion = await _context.CertificadoInspeccions.FindAsync(id);

            if (certificadoInspeccion == null)
            {
                return NotFound();
            }

            return certificadoInspeccion;
        }

        // PUT: api/CertificadoInspeccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificadoInspeccion(int id, CertificadoInspeccion certificadoInspeccion)
        {
            if (id != certificadoInspeccion.PkCertificadoInspeccion)
            {
                return BadRequest();
            }

            _context.Entry(certificadoInspeccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificadoInspeccionExists(id))
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

        // POST: api/CertificadoInspeccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CertificadoInspeccion>> PostCertificadoInspeccion(CertificadoInspeccion certificadoInspeccion)
        {
            _context.CertificadoInspeccions.Add(certificadoInspeccion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CertificadoInspeccionExists(certificadoInspeccion.PkCertificadoInspeccion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCertificadoInspeccion", new { id = certificadoInspeccion.PkCertificadoInspeccion }, certificadoInspeccion);
        }

        // DELETE: api/CertificadoInspeccions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificadoInspeccion(int id)
        {
            var certificadoInspeccion = await _context.CertificadoInspeccions.FindAsync(id);
            if (certificadoInspeccion == null)
            {
                return NotFound();
            }

            _context.CertificadoInspeccions.Remove(certificadoInspeccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertificadoInspeccionExists(int id)
        {
            return _context.CertificadoInspeccions.Any(e => e.PkCertificadoInspeccion == id);
        }
    }
}

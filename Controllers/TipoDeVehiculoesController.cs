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
    public class TipoDeVehiculoesController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public TipoDeVehiculoesController(BdFlkContext context)
        {
            _context = context;
        }

        // GET: api/TipoDeVehiculoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDeVehiculo>>> GetTipoDeVehiculos()
        {
            return await _context.TipoDeVehiculos.ToListAsync();
        }

        // GET: api/TipoDeVehiculoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDeVehiculo>> GetTipoDeVehiculo(int id)
        {
            var tipoDeVehiculo = await _context.TipoDeVehiculos.FindAsync(id);

            if (tipoDeVehiculo == null)
            {
                return NotFound();
            }

            return tipoDeVehiculo;
        }

        // PUT: api/TipoDeVehiculoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDeVehiculo(int id, TipoDeVehiculo tipoDeVehiculo)
        {
            if (id != tipoDeVehiculo.PkTipoDeVehiculos)
            {
                return BadRequest();
            }

            _context.Entry(tipoDeVehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDeVehiculoExists(id))
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

        // POST: api/TipoDeVehiculoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoDeVehiculo>> PostTipoDeVehiculo(TipoDeVehiculo tipoDeVehiculo)
        {
            _context.TipoDeVehiculos.Add(tipoDeVehiculo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoDeVehiculoExists(tipoDeVehiculo.PkTipoDeVehiculos))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoDeVehiculo", new { id = tipoDeVehiculo.PkTipoDeVehiculos }, tipoDeVehiculo);
        }

        // DELETE: api/TipoDeVehiculoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDeVehiculo(int id)
        {
            var tipoDeVehiculo = await _context.TipoDeVehiculos.FindAsync(id);
            if (tipoDeVehiculo == null)
            {
                return NotFound();
            }

            _context.TipoDeVehiculos.Remove(tipoDeVehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoDeVehiculoExists(int id)
        {
            return _context.TipoDeVehiculos.Any(e => e.PkTipoDeVehiculos == id);
        }
    }
}

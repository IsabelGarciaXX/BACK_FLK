using BACK_FLK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BACK_FLK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendarCitaController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public AgendarCitaController(BdFlkContext context)
        {
            _context = context;
        }

        // Métodos para Inspecciones

        [HttpGet("Inspecciones")]
        public async Task<ActionResult<IEnumerable<Inspeccione>>> GetInspecciones()
        {
            return await _context.Inspecciones.ToListAsync();
        }

        [HttpGet("Inspecciones/{id}")]
        public async Task<ActionResult<Inspeccione>> GetInspeccione(int id)
        {
            var inspeccione = await _context.Inspecciones.FindAsync(id);
            if (inspeccione == null)
            {
                return NotFound();
            }

            return inspeccione;
        }

        [HttpPut("Inspecciones/{id}")]
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

        [HttpPost("Inspecciones")]
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

            return CreatedAtAction(nameof(GetInspeccione), new { id = inspeccione.PkInspeccion }, inspeccione);
        }

        [HttpDelete("Inspecciones/{id}")]
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

        // Métodos para Servicios

        [HttpGet("Servicios")]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetServicios()
        {
            return await _context.Servicios.ToListAsync();
        }

        [HttpGet("Servicios/{id}")]
        public async Task<ActionResult<Servicio>> GetServicio(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            return servicio;
        }

        [HttpPut("Servicios/{id}")]
        public async Task<IActionResult> PutServicio(int id, Servicio servicio)
        {
            if (id != servicio.PkServicio)
            {
                return BadRequest();
            }

            _context.Entry(servicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioExists(id))
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

        [HttpPost("Servicios")]
        public async Task<ActionResult<Servicio>> PostServicio(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServicioExists(servicio.PkServicio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetServicio), new { id = servicio.PkServicio }, servicio);
        }

        [HttpDelete("Servicios/{id}")]
        public async Task<IActionResult> DeleteServicio(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicioExists(int id)
        {
            return _context.Servicios.Any(e => e.PkServicio == id);
        }
    }
}





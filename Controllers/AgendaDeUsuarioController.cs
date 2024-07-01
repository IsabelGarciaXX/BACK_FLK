using BACK_FLK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BACK_FLK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaDeUsuarioController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public AgendaDeUsuarioController(BdFlkContext context)
        {
            _context = context;
        }

        // GET: api/AgendaDeUsuario/TareasComoCertificador-fecha/{idUsuarioId}
        [HttpGet("TareasComoCertificador-fecha/{idUsuarioId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetCertificadoresDisponibles(int idUsuarioId)
        {
            var certificadorDisponible = await _context.CertificadoresDisponibles
                                         .FirstOrDefaultAsync(b => b.FkUsuario == idUsuarioId);

            if (certificadorDisponible == null)
            {
                return NotFound();
            }

            var inspecciones = await _context.Inspecciones
                                             .Where(i => i.FkCertificadorAsignado == certificadorDisponible.PkCertificadoresDisponibles &&
                                                         i.Estado == "Pendiente Evaluacion")
                                             .Select(inspeccion => new
                                             {
                                                 inspeccion.FkServicio,
                                                 inspeccion.FkServicioNavigation.FkTipoServicioNavigation.Nombre,
                                                 inspeccion.PkInspeccion,
                                                 inspeccion.FkTipoInspeccionNavigation.Titulo,
                                                 inspeccion.FkCertificadorAsignado,
                                                 inspeccion.FkEmpresasNavigation.RazonSocial,
                                             })
                                             .ToListAsync();

            if (!inspecciones.Any())
            {
                return NotFound();
            }

            return inspecciones;
        }



        // GET: api/AgendaDeUsuario/TareasComoInspector-Fechas/{idUsuarioId}
        [HttpGet("TareasComoInspector-Fechas/{idUsuarioId}")]
        public async Task<ActionResult<IEnumerable<object>>> TareasComoInspector(int idUsuarioId)
        {
            var inspectoresDisponibles = await _context.InspectoresDisponibles
                                             .FirstOrDefaultAsync(b => b.FkUsuario == idUsuarioId);
            if (inspectoresDisponibles == null)
            {
                return NotFound();
            }

            var inspectoresAsignados = await _context.AsignacionInspectores
                                             .FirstOrDefaultAsync(b => b.FkInpectoresDisponibles == inspectoresDisponibles.PkInpectoresDisponibles);
            if (inspectoresAsignados == null)
            {
                return NotFound();
            }

            var inspecciones = await _context.Inspecciones
                                             .Where(i => i.FkInspectoresAsignados == inspectoresAsignados.PkAsignacionId &&
                                                         i.Estado == "Pendiente")
                                             .Select(inspeccion => new
                                             {
                                                 inspeccion.FkServicio,
                                                 inspeccion.FkServicioNavigation.FkTipoServicioNavigation.Nombre,
                                                 inspeccion.PkInspeccion,
                                                 inspeccion.FkTipoInspeccionNavigation.Titulo,
                                                 inspeccion.FkCertificadorAsignado,
                                                 inspeccion.FkEmpresasNavigation.RazonSocial,
                                                 inspeccion.FechaHoraInicio,
                                                 inspeccion.FechaHoraFinalizacion,
                                                 inspeccion.Ubicacion
                                             })
                                             .ToListAsync();

            if (!inspecciones.Any())
            {
                return NotFound();
            }

            return inspecciones;
        }
    }
}

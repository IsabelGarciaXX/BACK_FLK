using BACK_FLK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BACK_FLK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerarCertificadoController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public GenerarCertificadoController(BdFlkContext context)
        {
            _context = context;
        }

        // GET: api/Inspecciones/InspeccionesPorMarca/{marcaVehiculo}
        [HttpGet("InspeccionesPorMarca/{marcaVehiculo}")]
        public async Task<ActionResult<IEnumerable<object>>> GetInspeccionesPorMarca(string marcaVehiculo)
        {
            var inspecciones = await _context.Inspecciones
                                             .Include(i => i.FkVehiculoNavigation)
                                             .Include(i => i.CertificadoInspeccions)
                                             .Where(i => i.FkVehiculoNavigation.Marca == marcaVehiculo && (i.Estado == "Apto" || i.Estado == "Observado"))
                                             .Select(i => new
                                             {
                                                 i.PkInspeccion,
                                                 i.FkServicio,
                                                 ServicioNombre = i.FkServicioNavigation.FkTipoServicioNavigation.Nombre,
                                                 i.FkEmpresas,
                                                 EmpresaNombre = i.FkEmpresasNavigation.Nombre,
                                                 i.FechaInspeccion,
                                                 i.Ubicacion,
                                                 i.Estado,
                                                 i.ObservacionesYRecomendaciones,
                                                 i.FechaHoraInicio,
                                                 i.FechaHoraFinalizacion,
                                                 Certificados = i.CertificadoInspeccions.Select(ci => new
                                                 {
                                                     ci.PkCertificadoInspeccion,
                                                     ci.FkInspeccion,
                                                     ci.FechaHoraRegistroCertificacion,
                                                     ci.FechaCaducidad,
                                                     ci.FondoCertificado
                                                 })
                                             })
                                             .ToListAsync();

            if (inspecciones == null || !inspecciones.Any())
            {
                return NotFound(new { message = "No se encontraron inspecciones finalizadas para la marca de vehículo dada." });
            }

            return inspecciones;
        }
        // GET: api/Inspecciones/InspeccionesPorId/{Id}
        [HttpGet("InspeccionesPorId/{Id}")]
        public async Task<ActionResult<IEnumerable<object>>> InspeccionesPorId(int Id)
        {
            // Fetch inspections from the database including related certifications
            var inspecciones = await _context.Inspecciones
                                             .Include(i => i.CertificadoInspeccions)
                                             .Where(i => i.PkInspeccion == Id &&
                                                         (i.Estado == "Apto" || i.Estado == "Observado"))
                                             .Select(i => new
                                             {
                                                 i.PkInspeccion,
                                                 i.FkServicio,
                                                 ServicioNombre = i.FkServicioNavigation.FkTipoServicioNavigation.Nombre,
                                                 i.FkEmpresas,
                                                 EmpresaNombre = i.FkEmpresasNavigation.Nombre,
                                                 i.FechaInspeccion,
                                                 i.Ubicacion,
                                                 i.Estado,
                                                 i.ObservacionesYRecomendaciones,
                                                 i.FechaHoraInicio,
                                                 i.FechaHoraFinalizacion,
                                                 Certificados = i.CertificadoInspeccions.Select(ci => new
                                                 {
                                                     ci.PkCertificadoInspeccion,
                                                     ci.FkInspeccion,
                                                     ci.FechaHoraRegistroCertificacion,
                                                     ci.FechaCaducidad,
                                                     ci.FondoCertificado
                                                 })
                                             })
                                             .ToListAsync();

            // Check if no inspections were found
            if (inspecciones == null || !inspecciones.Any())
            {
                return NotFound(new { message = "No se encontraron inspecciones finalizadas para la marca de vehículo dada." });
            }

            // Return the list of inspections
            return Ok(inspecciones);
        }
    }
}

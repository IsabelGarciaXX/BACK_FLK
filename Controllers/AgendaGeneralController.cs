using BACK_FLK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BACK_FLK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaGeneralController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public AgendaGeneralController(BdFlkContext context)
        {
            _context = context;
        }

        [HttpGet("InspeccionesConNombres")]
        public async Task<ActionResult<IEnumerable<object>>> GetInspeccionesConNombres()
        {
            var inspecciones = await _context.Inspecciones
                .Include(i => i.FkCertificadorAsignadoNavigation)
                    .ThenInclude(c => c.FkUsuarioNavigation)
                        .ThenInclude(u => u.Personals)
                .Include(i => i.FkInspectoresAsignadosNavigation)
                    .ThenInclude(a => a.FkInpectoresDisponiblesNavigation)
                        .ThenInclude(d => d.FkUsuarioNavigation)
                            .ThenInclude(u => u.Personals)
                .Include(i => i.FkTipoInspeccionNavigation)
                .Include(i => i.FkVehiculoNavigation)
                .Include(i => i.FkEmpresasNavigation)
                .Select(i => new
                {
                    i.FechaHoraInicio,
                    i.FechaHoraFinalizacion,
                    CertificadorNombre = i.FkCertificadorAsignadoNavigation.FkUsuarioNavigation.Personals.FirstOrDefault().Nombre,
                    InspectoresList = i.FkInspectoresAsignadosNavigation != null
                                      ? new List<object> {
                                          new {
                                              InspectorNombre = i.FkInspectoresAsignadosNavigation.FkInpectoresDisponiblesNavigation.FkUsuarioNavigation.Personals.FirstOrDefault().Nombre
                                          }
                                        }
                                      : new List<object>(),
                    i.FkTipoInspeccionNavigation.Titulo,
                    i.FkVehiculoNavigation.Marca,
                    i.Ubicacion,
                    EmpresaRuc = i.FkEmpresasNavigation.Ruc,
                    EmpresaRazonSocial = i.FkEmpresasNavigation.RazonSocial,
                })
                .ToListAsync();

            return Ok(inspecciones);
        }
    }
}

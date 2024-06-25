using BACK_FLK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

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

        // GET: api/AgendarCita/TiposServicio
        [HttpGet("TiposServicio")]
        public async Task<ActionResult<IEnumerable<TiposServicio>>> GetTiposServicio()
        {
            var tiposServicio = await _context.TiposServicios.ToListAsync();
            if (tiposServicio == null || !tiposServicio.Any())
            {
                return NotFound();
            }
            return tiposServicio;
        }

        // POST: api/AgendarCita/RegistrarServicio
        [HttpPost("RegistrarServicio")]
        public async Task<ActionResult<Servicio>> RegistrarServicio(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(RegistrarServicio), new { id = servicio.PkServicio }, servicio);
        }

        // GET: api/AgendarCita/VerificarEmpresaPorRuc/{ruc}
        [HttpGet("VerificarEmpresaPorRuc/{ruc}")]
        public async Task<ActionResult<Empresa>> VerificarEmpresaPorRuc(string ruc)
        {
            var empresa = await _context.Empresas.FirstOrDefaultAsync(e => e.Ruc == ruc);
            if (empresa == null)
            {
                return NotFound();
            }
            return empresa;
        }

        // POST: api/AgendarCita/RegistrarEmpresa
        [HttpPost("RegistrarEmpresa")]
        public async Task<ActionResult<Empresa>> RegistrarEmpresa(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(VerificarEmpresaPorRuc), new { ruc = empresa.Ruc }, empresa);
        }

        // GET: api/AgendarCita/VehiculosPorRuc/{ruc}
        [HttpGet("VehiculosPorRuc/{ruc}")]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculosPorRuc(string ruc)
        {
            var vehiculos = await _context.Vehiculos
                                          .Where(v => v.FkEmpresasNavigation.Ruc == ruc)
                                          .ToListAsync();
            if (vehiculos == null || !vehiculos.Any())
            {
                return NotFound();
            }
            return vehiculos;
        }
        // GET: api/AgendarCita/GetVehiculo/{id}
        [HttpGet("GetVehiculo/{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return vehiculo;
        }

        // POST: api/AgendarCita/RegistrarVehiculo
        [HttpPost("RegistrarVehiculo")]
        public async Task<ActionResult<Vehiculo>> RegistrarVehiculo(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VehiculoExists(vehiculo.PkVehiculo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVehiculo", new { id = vehiculo.PkVehiculo }, vehiculo);
        }

        // LOGICA PARA VERIFICAR SI EXISTE UN VEHICULO
        private bool VehiculoExists(int id)
        {
            return _context.Vehiculos.Any(e => e.PkVehiculo == id);
        }

        // GET: api/AgendarCita/InspeccionesPorInspector/{idInspector}
        [HttpGet("InspeccionesPorInspector/{idInspector}")]
        public async Task<ActionResult<IEnumerable<object>>> GetInspeccionesPorInspector(int idInspector)
        {
            var inspecciones = await _context.Inspecciones
                                             .Where(i => i.FkInspectoresAsignadosNavigation.FkInpectoresDisponibles == idInspector)
                                             .Join(_context.Personals,
                                                   inspeccion => inspeccion.FkInspectoresAsignadosNavigation.FkInpectoresDisponiblesNavigation.FkUsuario,
                                                   personal => personal.FkUsuario,
                                                   (inspeccion, personal) => new
                                                   {
                                                       inspeccion.FechaHoraInicio,
                                                       inspeccion.FechaHoraFinalizacion,
                                                       InspectorNombre = personal.Nombre
                                                   })
                                             .ToListAsync();

            if (inspecciones == null || !inspecciones.Any())
            {
                return NotFound();
            }

            return inspecciones;
        }

        // POST: api/AgendarCita/RegistrarAsignacionInspectores
        [HttpPost("RegistrarAsignacionInspectores")]
        public async Task<ActionResult<AsignacionInspectore>> RegistrarAsignacionInspectores(AsignacionInspectore asignacion)
        {
            _context.AsignacionInspectores.Add(asignacion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(RegistrarAsignacionInspectores), new { id = asignacion.PkAsignacionId }, asignacion);
        }
        // GET: api/AgendarCita/CertificadoresDisponiblesPorFechaYTipo/{fechaYHora}/{tipoInspeccionId}/{idInspectoresAsignados}
        [HttpGet("CertificadoresDisponiblesPorFechaYTipo/{fechaYHora}/{tipoInspeccionId}/{idInspectoresAsignados}")]
        public async Task<ActionResult<IEnumerable<object>>> GetCertificadoresDisponiblesPorFechaYTipo(DateTime fechaYHora, int tipoInspeccionId, int idInspectoresAsignados)
        {
            var fecha = DateOnly.FromDateTime(fechaYHora);

            // Obtener los IDs de usuario de los inspectores asignados
            var inspectoresAsignadosUsuarios = await _context.AsignacionInspectores
                                                             .Where(ai => ai.PkAsignacionId == idInspectoresAsignados)
                                                             .Join(_context.InspectoresDisponibles,
                                                                   ai => ai.FkInpectoresDisponibles,
                                                                   id => id.PkInpectoresDisponibles,
                                                                   (ai, id) => id.FkUsuario)
                                                             .ToListAsync();

            var certificadores = await _context.CertificadoresDisponibles
                                               .Where(c => c.FkTipoInspeccion == tipoInspeccionId &&
                                                           c.FechaEmisionCertificado <= fecha &&
                                                           c.FechaVencimientoCertificado >= fecha &&
                                                           !inspectoresAsignadosUsuarios.Contains(c.FkUsuario))
                                               .Join(_context.Personals,
                                                     certificador => certificador.FkUsuario,
                                                     personal => personal.FkUsuario,
                                                     (certificador, personal) => new
                                                     {
                                                         certificador.PkCertificadoresDisponibles,
                                                         certificador.FechaEmisionCertificado,
                                                         certificador.FechaVencimientoCertificado,
                                                         CertificadorNombre = personal.Nombre,
                                                         CertificadorDni = personal.Dni,
                                                         CertificadorEmail = personal.Email,
                                                         CertificadorDireccion = personal.Direccion,
                                                         CertificadorTelefono = personal.Telefono
                                                     })
                                               .ToListAsync();

            if (certificadores == null || !certificadores.Any())
            {
                return NotFound(new { message = "No se encontraron certificadores disponibles que no sean los mismos inspectores asignados." });
            }

            return certificadores;
        }






        // POST: api/AgendarCita/RegistrarInspeccion
        [HttpPost("RegistrarInspeccion")]
        public async Task<ActionResult<Inspeccione>> RegistrarInspeccion(Inspeccione inspeccion)
        {
            _context.Inspecciones.Add(inspeccion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(RegistrarInspeccion), new { id = inspeccion.PkInspeccion }, inspeccion);
        }

        // GET: api/AgendarCita/TiposInspeccion
        [HttpGet("TiposInspeccion")]
        public async Task<ActionResult<IEnumerable<TipoInspeccion>>> GetTiposInspeccion()
        {
            var tiposInspeccion = await _context.TipoInspeccions.ToListAsync();
            if (tiposInspeccion == null || !tiposInspeccion.Any())
            {
                return NotFound();
            }
            return tiposInspeccion;
        }
        // GET: api/AgendarCita/InspectoresDisponiblesPorTipoInspeccion/{tipoInspeccionId}
        [HttpGet("InspectoresDisponiblesPorTipoInspeccion/{tipoInspeccionId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetInspectoresDisponiblesPorTipoInspeccion(int tipoInspeccionId)
        {
            var inspectoresDisponibles = await _context.InspectoresDisponibles
                                                       .Where(i => i.FkTipoInspeccion == tipoInspeccionId)
                                                       .Select(i => new
                                                       {
                                                           i.PkInpectoresDisponibles,
                                                           i.FkUsuario,
                                                           i.FechaEmisionCertificado,
                                                           i.FechaVencimientoCertificado,
                                                           i.FkTipoInspeccion,
                                                           i.CertificadoPdf,
                                                           i.FirmaYselloDigital,
                                                           NombreInspector = i.FkUsuarioNavigation.Personals
                                                                                .Where(p => p.FkUsuario == i.FkUsuario)
                                                                                .Select(p => p.Nombre)
                                                                                .FirstOrDefault()
                                                       })
                                                       .ToListAsync();

            if (inspectoresDisponibles == null || !inspectoresDisponibles.Any())
            {
                return NotFound(new { message = "No se encontraron inspectores disponibles para el tipo de inspección dado" });
            }

            return inspectoresDisponibles;
        }


    }
}

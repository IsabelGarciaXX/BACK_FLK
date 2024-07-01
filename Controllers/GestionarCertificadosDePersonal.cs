using BACK_FLK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACK_FLK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionarCertificadosDePersonal : ControllerBase
    {
        private readonly BdFlkContext _context;

        public GestionarCertificadosDePersonal(BdFlkContext context)
        {
            _context = context;
        }

        // GET: api/GestionarCertificadosDePersonal/InspectoresDisponiblesHoy
        [HttpGet("InspectoresDisponiblesHoy")]
        public async Task<ActionResult<IEnumerable<object>>> GetInspectoresDisponibles()
        {
            var fechaActual = DateOnly.FromDateTime(DateTime.Now);

            var inspectores = await _context.InspectoresDisponibles
                .Include(i => i.FkUsuarioNavigation)
                .ThenInclude(u => u.Personals)
                .Where(i => i.FechaEmisionCertificado <= fechaActual && i.FechaVencimientoCertificado >= fechaActual)
                .Select(i => new
                {
                    Id = i.PkInpectoresDisponibles,
                    Tipo_De_Inspeccion= i.FkTipoInspeccionNavigation.Titulo,
                    NombrePersonal = i.FkUsuarioNavigation.Personals.FirstOrDefault().Nombre,
                    FechaVencimiento = i.FechaVencimientoCertificado
                })
                .ToListAsync();

            return Ok(inspectores);
        }
        // GET: api/GestionarCertificadosDePersonal/CertificadoresDisponiblesHoy
        [HttpGet("CertificadoresDisponiblesHoy")]
        public async Task<ActionResult<IEnumerable<object>>> GetCertificadoresDisponibles()
        {
            var fechaActual = DateOnly.FromDateTime(DateTime.Now);

            var certificadores = await _context.CertificadoresDisponibles
                .Include(i => i.FkUsuarioNavigation)
                .ThenInclude(u => u.Personals)
                .Where(i => i.FechaEmisionCertificado <= fechaActual && i.FechaVencimientoCertificado >= fechaActual)
                .Select(i => new
                {
                    Id = i.PkCertificadoresDisponibles,
                    Tipo_De_Inspeccion = i.FkTipoInspeccionNavigation.Titulo,
                    NombrePersonal = i.FkUsuarioNavigation.Personals.FirstOrDefault().Nombre,
                    FechaVencimiento = i.FechaVencimientoCertificado
                })
                .ToListAsync();

            return Ok(certificadores);
        }
        // GET: api/GestionarCertificadosDePersonal/DocentesDisponiblesHoy
        [HttpGet("DocentesDisponiblesHoy")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetDocentesDisponibles()
        {
            var fechaActual = DateOnly.FromDateTime(DateTime.Now);

            var docentes = await _context.DocenteDisponibles
                .Include(i => i.FkUsuarioNavigation)
                .ThenInclude(u => u.Personals)
                .Where(i => i.FechaEmisionCertificado <= fechaActual && i.FechaVencimientoCertificado >= fechaActual)
                .Select(i => new
                {
                    Id = i.PkDocenteDisponibles,
                    NombrePersonal = i.FkUsuarioNavigation.Personals.FirstOrDefault().Nombre,
                    FechaVencimiento = i.FechaVencimientoCertificado
                })
                .ToListAsync();

            return Ok(docentes);
        }

        // GET: api/GestionarCertificadosDePersonal/UsuariosConRol2
        [HttpGet("UsuariosConRol2")]
        public async Task<ActionResult<IEnumerable<object>>> GetUsuariosConRol2()
        {
            var usuariosConRol2 = await _context.Usuarios
                .Include(u => u.Personals)
                .Where(u => u.FkRol == 2)
                .Select(u => new
                {
                    IdUsuario = u.PkUsuario,
                    NombrePersonal = u.Personals.FirstOrDefault().Nombre
                })
                .ToListAsync();

            return Ok(usuariosConRol2);
        }

        // GET: api/GestionarCertificadosDePersonal/TiposDeInspeccion
        [HttpGet("TiposDeInspeccion")]
        public async Task<ActionResult<IEnumerable<object>>> GetTiposDeInspeccion()
        {
            var tiposDeInspeccion = await _context.TipoInspeccions
                .Select(t => new
                {
                    Id = t.PkTipoInspeccion,
                    Titulo = t.Titulo
                })
                .ToListAsync();

            return Ok(tiposDeInspeccion);
        }
    }
}
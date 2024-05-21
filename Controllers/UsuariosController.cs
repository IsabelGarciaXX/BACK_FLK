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
    public class UsuariosController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public UsuariosController(BdFlkContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }
        // POST: api/Usuarios/Login
        [HttpPost("Login")]
        public async Task<ActionResult<Usuario>> Login(Usuario usuario)
        {
            try
            {
                var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == usuario.NombreUsuario && u.Contraseña == usuario.Contraseña);

                if (user == null)
                {
                    return Unauthorized();
                }
                return user;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            else
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return Created("{usuario.PkUsuario}", usuario);
            }
        }
        // return CreatedAtAction("GetUsuario", new { id = usuario.PkUsuario }, usuario);
        //}
        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.PkUsuario == id);
        }
    }
}
    


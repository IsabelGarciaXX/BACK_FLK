using BACK_FLK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BACK_FLK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuperacionContraseñaController : ControllerBase
    {
        private readonly BdFlkContext _context;

        public AgendaDeUsuarioController(BdFlkContext context)
        {
            _context = context;
        }
        [HttpGet]
    }
}

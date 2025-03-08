using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasApi.Data;

namespace TareasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController(TareasDbContext context) : ControllerBase
    {
        private readonly TareasDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> GetTareas()
        {
            return Ok(await _context.Usuarios.ToArrayAsync());
        }
    }
}

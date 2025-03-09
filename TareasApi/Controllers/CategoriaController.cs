using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TareasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        //private readonly TareasDbContext _context = context;

        //[HttpGet]
        //public async Task<ActionResult<List<Categoria>>> GetTareas()
        //{
        //    return Ok(await _context.Categoria.ToArrayAsync());
        //}

    }
}

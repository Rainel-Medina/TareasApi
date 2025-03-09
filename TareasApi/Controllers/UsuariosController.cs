using CapaDatos;
using CapaNegocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasApi.Data;


namespace TareasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //private readonly TareasDbContext _context = context;

        IUsuarios _usuarios;
        public UsuariosController(IUsuarios usuarios)
        {
            _usuarios = usuarios;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetUsuarios()
        {
            return _usuarios.GetUsuarios();
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Usuarios>>> GetUsuarios()
        //{
        //    return Ok(await _context.Usuarios.ToArrayAsync());
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Usuarios>> GetUsuariosById(int id)
        //{
        //    var usuario = await _context.Usuarios.FindAsync(id);
        //    if (usuario is null)
        //        return NotFound();

        //    return Ok(usuario);
        //}

        //[HttpPost]
        //public async Task<ActionResult<Usuarios>> AddUsuarios(Usuarios newUsuario)
        //{
        //    if (newUsuario is null)
        //        return BadRequest();

        //   _context.Usuarios.Add(newUsuario);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetUsuariosById), new { id = newUsuario.Id_Usuario }, newUsuario);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateUsuarios(int id, Usuarios updatedUsuarios)
        //{
        //    var usuarios = await _context.Usuarios.FindAsync(id);
        //    if (usuarios is null)
        //        return NotFound();

        //    usuarios.Nombre = updatedUsuarios.Nombre;
        //    usuarios.Apellido = updatedUsuarios.Apellido;
        //    usuarios.Sexo = updatedUsuarios.Sexo;

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUsuarios(int id)
        //{
        //    var usuarios = await _context.Usuarios.FindAsync(id);
        //    if (usuarios is null)
        //        return NotFound();

        //   _context.Usuarios.Remove(usuarios);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}

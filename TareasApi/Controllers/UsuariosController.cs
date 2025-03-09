using CapaDatos;
using CapaDatos.DTO;
using CapaNegocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuariosById(int id)
        {
            var usuario = await Task.Run(() => _usuarios.GetUsuarios().Find(u => u.IdUsuario == id));
            if (usuario is null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult<Usuario> AddUsuarios([FromBody] UsuarioDTO newUsuario)
        {
            if (newUsuario == null)
                return BadRequest(new { message = "El campo 'newUsuario' es obligatorio." });

            var usuario = new Usuario
            {
                Nombre = newUsuario.Nombre,
                Apellido = newUsuario.Apellido,
                Sexo = newUsuario.Sexo,
                FechaCreacion = DateTime.UtcNow, // Asigna un valor válido
            };

            _usuarios.AddUsuario(usuario);

            return CreatedAtAction(nameof(GetUsuariosById), new { id = usuario.IdUsuario }, usuario);
        }

        [HttpPut("{id}")]
        public ActionResult<Usuario> UpdateUsuario(int id, [FromBody] UsuarioDTO usuarioDto)
        {
            if (usuarioDto == null)
                return BadRequest(new { message = "El campo 'usuario' es obligatorio." });

            var usuarioExistente = _usuarios.GetUsuarios().Find(u => u.IdUsuario == id);
            if (usuarioExistente == null)
                return NotFound(new { message = "Usuario no encontrado." });

            usuarioExistente.Nombre = usuarioDto.Nombre;
            usuarioExistente.Apellido = usuarioDto.Apellido;
            usuarioExistente.Sexo = usuarioDto.Sexo;
            usuarioExistente.FechaActualizacion = DateTime.UtcNow;

            _usuarios.UpdateUsuario(usuarioExistente);

            return Ok(usuarioExistente);
        }



        //[HttpGet]
        //public async Task<ActionResult<List<Usuarios>>> GetUsuarios()
        //{
        //    return Ok(await _context.Usuarios.ToArrayAsync());
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Usuario>> GetUsuariosById(int id)
        //{
        //    var usuario = await _usuarios.GetUsuarios.FindAsync(id);
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

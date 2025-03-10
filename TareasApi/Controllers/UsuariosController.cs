using CapaDatos;
using CapaDatos.DTO.UsuarioDTO;
using CapaNegocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TareasApi.Infraestructura.Repositories;


namespace TareasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IGenericRepository<Usuario> _repository;

        IUsuarios _usuarios;
        public UsuariosController(IGenericRepository<Usuario> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _repository.GetAll();
            return Ok(usuarios.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuariosById(int id)
        {
            var usuario = await _repository.Get(u => u.IdUsuario == id);
            if (usuario is null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> AddUsuarios( UsuarioDTO newUsuario)
        {
            await _repository.Add(newUsuario);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> UpdateUsuario(int id, UpdateUsuarioDTO updateUsuarioDto)
        {   
           
            await _repository.Update(updateUsuarioDto);
            return Ok();
            
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

using CapaDatos.DTO.TareaDTO;
using CapaDatos.DTO.UsuarioDTO;
using CapaDatos.Modelos;
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
            if (string.IsNullOrEmpty(newUsuario.Nombre))
            {
                return BadRequest(new { Message = "El nombre es obligatorio" });
            }

            if (string.IsNullOrEmpty(newUsuario.Apellido))
            {
                return BadRequest(new { Message = "El estado de la tarea es obligatorio" });
            }

            if (newUsuario.Sexo <= 0)
            {
                return BadRequest(new { Message = "El sexo del usuario es obligatorio" });
            }

            await _repository.Add(newUsuario);

            return Ok(new { Message = "Usuario creado correctamente", UsuarioDTO = newUsuario });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> UpdateUsuario(int id, UpdateUsuarioDTO updateUsuarioDto)
        {

            if (string.IsNullOrEmpty(updateUsuarioDto.Nombre))
            {
                return BadRequest(new { Message = "El nombre es obligatorio" });
            }

            if (string.IsNullOrEmpty(updateUsuarioDto.Apellido))
            {
                return BadRequest(new { Message = "El apellido es obligatorio" });
            }

            if (updateUsuarioDto.Sexo <= 0)
            {
                return BadRequest(new { Message = "El sexo del usuario es obligatorio" });
            }

            await _repository.Update(updateUsuarioDto);

            return Ok(new { Message = "Usuario actualizado correctamente", UpdateUsuarioDTO = updateUsuarioDto });

        }
    }
}

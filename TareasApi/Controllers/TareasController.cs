using CapaDatos;
using CapaDatos.DTO.TareaDTO;
using CapaDatos.DTO.UsuarioDTO;
using CapaNegocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using TareasApi.Infraestructura.Repositories;


namespace TareasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TareasController : ControllerBase
    {
        private readonly IGenericRepository<Tarea> _repository;

        ITarea _tarea;
        private readonly IUsuarios _usuarios;
        private readonly ICategoria _categorias; // Añadir esta línea

        public TareasController(IGenericRepository<Tarea> repository) // Modificar esta línea
        {
            _repository = repository;
            //_tarea = tarea;
            //_usuarios = usuarios; // Añadir esta línea
            //_categorias = categorias; // Añadir esta línea
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
        {
            var tarea = await _repository.GetAll();
            return Ok(tarea.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetTareasById(int id)
        {
            var tarea = await _repository.Get(u => u.IdTarea == id);
            if (tarea is null)
                return NotFound();

            return Ok(tarea);
        }

        [HttpPost]
        public async Task<ActionResult<Tarea>> AddTareas(TareaDTO newTareaDTO)
        {
            await _repository.Add(newTareaDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tarea>> UpdateTarea(int id, UpdateTareaDTO updateTareaDto)
        {

            await _repository.Update(updateTareaDto);
            return Ok();

        }


        //[HttpGet]
        //public IEnumerable<Tarea> GetTareas()
        //{
        //    return _tarea.GetTareas();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Tarea>> GetTareasById(int id)
        //{
        //    var tarea = await Task.Run(() => _tarea.GetTareas().Find(u => u.IdTarea == id));
        //    if (tarea is null)
        //        return NotFound();

        //    return Ok(tarea);
        //}

        //[HttpGet("usuarios")]
        //public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        //{
        //    var usuarios = _usuarios.GetUsuarios();  // Método en LogicaUsuarios que devuelve todos los usuarios
        //    return Ok(usuarios);
        //}

        //[HttpGet("categorias")]
        //public ActionResult<IEnumerable<Categorium>> GetCategorias()
        //{
        //    var categorias = _categorias.GetCategorias();  // Método en LogicaCategorias que devuelve todas las categorías
        //    return Ok(categorias);
        //}

        // Endpoint para agregar una tarea
        //[HttpPost]
        //public ActionResult<Tarea> AddTareas([FromBody] TareaDTO newTareaDTO)
        //{
        //    if (newTareaDTO == null)
        //        return BadRequest();

        //    // Crear la tarea a partir del DTO
        //    var tarea = new Tarea
        //    {
        //        Descripcion = newTareaDTO.Descripcion,
        //        EstadoTarea = newTareaDTO.EstadoTarea,
        //        IdCategoria = newTareaDTO.IdCategoria,
        //        IdUsuario = newTareaDTO.IdUsuario,
        //        FechaCreacion = DateTime.UtcNow, // Asigna la fecha de creación
        //    };

        //    try
        //    {
        //        // Añadir la tarea a la base de datos
        //        _tarea.AddTareas(tarea);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }

        //    return CreatedAtAction(nameof(GetTareasById), new { id = tarea.IdTarea }, tarea);
        //}

        //[HttpPut("{id}")]
        //public ActionResult<Tarea> UpdateTarea(int id, [FromBody] TareaDTO tareaDto)
        //{
        //    // Validar que el DTO no sea nulo
        //    if (tareaDto == null)
        //        return BadRequest(new { message = "El campo 'tarea' es obligatorio." });

        //    // Buscar la tarea existente por su id
        //    var tareaExistente = _tarea.GetTareas().Find(t => t.IdTarea == id);
        //    if (tareaExistente == null)
        //        return NotFound(new { message = "Tarea no encontrada." });

        //    // Actualizar las propiedades de la tarea existente con los datos del DTO
        //    tareaExistente.Descripcion = tareaDto.Descripcion;
        //    tareaExistente.EstadoTarea = tareaDto.EstadoTarea;
        //    tareaExistente.IdCategoria = tareaDto.IdCategoria;
        //    tareaExistente.IdUsuario = tareaDto.IdUsuario;
        //    tareaExistente.FechaActualizacion = DateTime.UtcNow;

        //    // Actualizar la tarea en el repositorio
        //    _tarea.UpdateTarea(tareaExistente);

        //    // Devolver la tarea actualizada
        //    return Ok(tareaExistente);
        //}

    }
}

using CapaDatos;
using CapaDatos.DTO;
using CapaNegocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CapaNegocio.Interfaces.ITarea;

namespace TareasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        ICategoria _categoria;
        public CategoriaController(ICategoria categoria)
        {
            _categoria = categoria;
        }

        [HttpGet]
        public IEnumerable<Categorium> GetCategoria()
        {
            return _categoria.GetCategorias();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categorium>> GetCategoriaById(int id)
        {
            var categoria = await Task.Run(() => _categoria.GetCategorias().Find(u => u.IdCategoria == id));
            if (categoria is null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult<Categorium> AddCategoria([FromBody] CategoriaDTO newCategoria)
        {
            if (newCategoria == null)
                return BadRequest(new { message = "El campo 'newCategoria' es obligatorio." });

            var categoria = new Categorium
            {
                NombreCategoria = newCategoria.NombreCategoria,
                FechaCreacion = DateTime.UtcNow, // Asigna un valor válido
            };

            _categoria.AddCategoria(categoria);

            return CreatedAtAction(nameof(GetCategoriaById), new { id = categoria.IdCategoria }, categoria);
        }


        [HttpPut("{id}")]
        public ActionResult<Categorium> UpdateCategoria(int id, [FromBody] CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null)
                return BadRequest(new { message = "El campo 'categoria' es obligatorio." });

            var categoriaExistente = _categoria.GetCategorias().Find(u => u.IdCategoria == id);
            if (categoriaExistente == null)
                return NotFound(new { message = "Categoria no encontrada." });

            categoriaExistente.NombreCategoria = categoriaDto.NombreCategoria;
            categoriaExistente.FechaActualizacion = DateTime.UtcNow;

            _categoria.UpdateCategoria(categoriaExistente);

            return Ok(categoriaExistente);
        }


    }
}

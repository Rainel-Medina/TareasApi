using CapaDatos.DTO.CategoriaDTO;
using CapaDatos.DTO.TareaDTO;
using CapaDatos.Modelos;
using CapaNegocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasApi.Infraestructura.Repositories;
using static CapaNegocio.Interfaces.ITarea;

namespace TareasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IGenericRepository<Categorium> _repository;

        ICategoria _categoria;
        public CategoriaController(IGenericRepository<Categorium> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorium>>> GetCategoria()
        {
            var categoria = await _repository.GetAll();
            return Ok(categoria.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categorium>> GetCategoriaById(int id)
        {
            var categoria = await _repository.Get(u => u.IdCategoria == id);
            if (categoria is null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<Tarea>> AddCategoria(CategoriaDTO newCategoriaDTO)
        {
            if (string.IsNullOrEmpty(newCategoriaDTO.NombreCategoria))
            {
                return BadRequest(new { Message = "El nombre de la categoría es obligatorio " });
            }

            await _repository.Add(newCategoriaDTO);

            return Ok(new { Message = "Categoría creada correctamente", CategoriaDTO = newCategoriaDTO });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Categorium>> UpdateCategoria(int id, UpdateCategoriaDTO updateCategoriaDto)
        {
            if (string.IsNullOrEmpty(updateCategoriaDto.NombreCategoria))
            {
                return BadRequest(new { Message = "El nombre de la categoría es obligatorio " });
            }

            await _repository.Update(updateCategoriaDto);

            return Ok(new { Message = "Categoría actualizada correctamente", UpdateCategoriaDTO = updateCategoriaDto });

        }     
    }
}

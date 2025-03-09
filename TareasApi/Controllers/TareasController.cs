using CapaDatos;
using CapaNegocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using TareasApi.Data;

namespace TareasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController: ControllerBase
    {

        ITarea _tarea;
        public TareasController(ITarea tarea)
        {
            _tarea = tarea;
        }

        [HttpGet]
        public IEnumerable<Tarea> GetTareas()
        {
            return _tarea.GetTareas();
        }
        //private readonly TareasDbContext _context = context;

        //[HttpGet]
        //public async Task<ActionResult<List<Tarea>>> GetTareas()
        //{
        //    return Ok(await _context.Tarea.ToArrayAsync());
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Tarea>> GetTareasById(int id)
        //{
        //    var tarea = await _context.Tarea.FindAsync(id);
        //    if (tarea is null)
        //        return NotFound();

        //    return Ok(tarea);
        //}



        //static private List<Tarea> tareas = new List<Tarea>
        //{
        //    new Tarea
        //    {
        //        Id_Tarea = 1,
        //        Descripcion = "Comprar"
        //    },
        //    new Tarea
        //    {
        //        Id_Tarea = 2,
        //        Descripcion = "Ventas"
        //    }
        //};

        //[HttpGet("{id}")]
        //public ActionResult<Tarea> GetTareasById(int id)
        //{
        //    var tarea = tareas.FirstOrDefault(g => g.Id_Tarea == id);
        //    if (tarea is null)
        //        return NotFound();

        //    return Ok(tarea);
        //}

        //[HttpPost]
        //public ActionResult<Tarea> AddTareas(Tarea newTarea)
        //{
        //    if (newTarea is null)
        //        return BadRequest();

        //    newTarea.Id_Tarea = tareas.Max(g => g.Id_Tarea) + 1;
        //    tareas.Add(newTarea);
        //    return CreatedAtAction(nameof(GetTareasById), new { id = newTarea.Id_Tarea }, newTarea);
        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateTareas(int id, Tarea updatedTareas)
        //{
        //    var tarea = tareas.FirstOrDefault(g => g.Id_Tarea == id);
        //    if (tarea is null)
        //        return NotFound();

        //    tarea.Descripcion = updatedTareas.Descripcion;

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteTareas(int id)
        //{
        //    var tarea = tareas.FirstOrDefault(g => g.Id_Tarea == id);
        //    if (tarea is null)
        //        return NotFound();

        //    tareas.Remove(tarea);

        //    return NoContent();
        //}
    }
}

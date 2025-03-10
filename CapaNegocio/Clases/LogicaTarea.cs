using CapaDatos;
using CapaDatos.Infraestructura;
using CapaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaNegocio.Interfaces.ITarea;

namespace CapaNegocio.Clases
{
    public class LogicaTarea : ITarea
    {
        private TareasContext db;

        public LogicaTarea(TareasContext db)
        {
            this.db = db;
        }

        public List<Tarea> GetTareas()
        {
            return db.Tareas.Include(t => t.IdCategoriaNavigation).Include(t => t.IdUsuarioNavigation).ToList();
        }

        public void AddTareas(Tarea tarea)
        {
            // Validar que el usuario y la categoría existan
            var usuario = db.Usuarios.Find(tarea.IdUsuario);
            var categoria = db.Categoria.Find(tarea.IdCategoria);

            if (usuario == null || categoria == null)
            {
                throw new ArgumentException("El usuario o la categoría no existen.");
            }

            db.Tareas.Add(tarea);
            db.SaveChanges();
        }

        public void UpdateTarea(Tarea tarea)
        {
            var tareaExistente = db.Tareas.Find(tarea.IdTarea);
            if (tareaExistente != null)
            {
                tareaExistente.Descripcion = tarea.Descripcion;
                tareaExistente.EstadoTarea = tarea.EstadoTarea;
                tareaExistente.IdCategoria = tarea.IdCategoria;              
                tareaExistente.IdUsuario = tarea.IdUsuario;
                tareaExistente.FechaActualizacion = DateTime.UtcNow;

                db.Tareas.Update(tareaExistente);
                db.SaveChanges();
            }
        }
    }


}

using CapaDatos;
using CapaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return db.Tareas.ToList();
        }

    }
   
}

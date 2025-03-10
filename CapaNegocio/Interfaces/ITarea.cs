using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaNegocio.Interfaces.ITarea;

namespace CapaNegocio.Interfaces
{
    public interface ITarea
    {
        public interface IUsuarios
        {
            List<Usuario> GetUsuarios();
        }
        public interface ICategorias
        {
            List<Categorium> GetCategorias();
        }
        List<Tarea> GetTareas();
        void AddTareas(Tarea tarea);
        void UpdateTarea(Tarea tarea);
    }
}

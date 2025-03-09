using CapaDatos;
using CapaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Clases
{
    public class LogicaUsuarios : IUsuarios
    {
        private TareasContext db;

        public LogicaUsuarios(TareasContext db)
        {
            this.db = db;
        }

        public List<Usuario> GetUsuarios()
        {
            return db.Usuarios.ToList();
        }
    }
}

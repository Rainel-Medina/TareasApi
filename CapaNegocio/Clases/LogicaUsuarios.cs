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
        private readonly TareasContext db;

        public LogicaUsuarios(TareasContext db)
        {
            this.db = db;
        }

        public List<Usuario> GetUsuarios()
        {
            return db.Usuarios.ToList();
        }

        public void AddUsuario(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            var usuarioExistente = db.Usuarios.Find(usuario.IdUsuario);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nombre = usuario.Nombre;
                usuarioExistente.Apellido = usuario.Apellido;
                usuarioExistente.Sexo = usuario.Sexo;
                usuarioExistente.FechaActualizacion = DateTime.UtcNow; // Se actualiza la fecha

                db.Usuarios.Update(usuarioExistente);
                db.SaveChanges();
            }
        }


    }
}

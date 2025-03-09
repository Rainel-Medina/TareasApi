using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface IUsuarios
    {
        List<Usuario> GetUsuarios();
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
    }
}

using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface ICategoria
    {
        List<Categorium> GetCategorias();
        void AddCategoria(Categorium categoria);
        void UpdateCategoria(Categorium categoria);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.DTO.CategoriaDTO
{
    public class CategoriaDTO
    {
        public string NombreCategoria { get; set; } = null!;

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    }
}

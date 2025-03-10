using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.DTO.CategoriaDTO
{
    public class UpdateCategoriaDTO
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } = null!;
        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;

    }
}

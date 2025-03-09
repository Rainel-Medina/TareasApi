using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.DTO
{
    public class TareaDTO
    {
        public string Descripcion { get; set; }
        public int EstadoTarea { get; set; }
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
    }

}

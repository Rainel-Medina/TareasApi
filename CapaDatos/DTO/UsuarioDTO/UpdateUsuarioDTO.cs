using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.DTO.UsuarioDTO
{
    public class UpdateUsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Sexo { get; set; }
        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
    }
}

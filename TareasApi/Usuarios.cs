using System.ComponentModel.DataAnnotations;

namespace TareasApi
{
    public class Usuarios
    {
        [Key]
        public int Id_Usuario { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Sexo { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        public DateTime Fecha_Actualizacion { get; set; }
    }
}

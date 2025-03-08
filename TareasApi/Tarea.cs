using System.ComponentModel.DataAnnotations;

namespace TareasApi
{
    public class Tarea
    {
        [Key]
        public int Id_Tarea { get; set; }

        public string  Descripcion { get; set; }

        public int Estado_tarea { get; set; }

        public int Id_Categoria { get; set; }

        public int Id_Usuario { get; set; }

        public DateTime Fecha_Creacion{ get; set; }

        public DateTime Fecha_Actualizacion { get; set; }
    }
}

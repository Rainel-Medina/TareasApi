using System.ComponentModel.DataAnnotations;

namespace TareasApi
{
    public class Categoria
    {
        [Key]
        public int Id_Categoria { get; set; }

        public string Nombre_Categoria { get; set; }

        public DateTime Fecha_Creacion  { get; set; }

        public DateTime Fecha_Actualizacion { get; set; }

    }
}

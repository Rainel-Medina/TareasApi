using System;
using System.Collections.Generic;

namespace CapaDatos.Modelos;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}

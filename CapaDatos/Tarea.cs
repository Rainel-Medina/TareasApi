using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CapaDatos;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public string Descripcion { get; set; } = null!;

    public int EstadoTarea { get; set; }

    public int IdCategoria { get; set; }

    public int IdUsuario { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;

    public virtual Categorium IdCategoriaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}

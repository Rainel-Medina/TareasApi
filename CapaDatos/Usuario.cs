﻿using System;
using System.Collections.Generic;

namespace CapaDatos;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int Sexo { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;


    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}

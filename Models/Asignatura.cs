using System;
using System.Collections.Generic;

namespace BACK_FLK.Models;

public partial class Asignatura
{
    public int PkAsignatura { get; set; }

    public string? Nombre { get; set; }

    public string? HorasTeoria { get; set; }

    public string? HoraPractica { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    public virtual ICollection<DocenteDisponible> DocenteDisponibles { get; set; } = new List<DocenteDisponible>();
}

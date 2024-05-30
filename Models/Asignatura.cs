using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BACK_FLK.Models;

public partial class Asignatura
{
    public int PkAsignatura { get; set; }

    public string? Nombre { get; set; }

    public string? HorasTeoria { get; set; }

    public string? HoraPractica { get; set; }

    [JsonIgnore]
    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    [JsonIgnore]
    public virtual ICollection<DocenteDisponible> DocenteDisponibles { get; set; } = new List<DocenteDisponible>();
}

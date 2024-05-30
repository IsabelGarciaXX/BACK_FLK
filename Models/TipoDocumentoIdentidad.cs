using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BACK_FLK.Models;

public partial class TipoDocumentoIdentidad
{
    public int PkTipoDocumentoIdentidad { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    [JsonIgnore]

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}

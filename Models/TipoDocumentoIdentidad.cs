using System;
using System.Collections.Generic;

namespace BACK_FLK.Models;

public partial class TipoDocumentoIdentidad
{
    public int PkTipoDocumentoIdentidad { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}

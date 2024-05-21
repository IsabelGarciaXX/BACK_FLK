using System;
using System.Collections.Generic;

namespace BACK_FLK.Models;

public partial class Alumno
{
    public int PkAlumno { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? NroDocumento { get; set; }

    public int? FkTipoDocumentoIdentidad { get; set; }

    public virtual ICollection<AlumnoXcurso> AlumnoXcursos { get; set; } = new List<AlumnoXcurso>();

    public virtual TipoDocumentoIdentidad? FkTipoDocumentoIdentidadNavigation { get; set; }
}

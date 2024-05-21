using System;
using System.Collections.Generic;

namespace BACK_FLK.Models;

public partial class AlumnoXcurso
{
    public int PkParticipantesCursos { get; set; }

    public int? FkCurso { get; set; }

    public int? PkAlumno { get; set; }

    public int? NotaTeoria { get; set; }

    public int? NotaPractica { get; set; }

    public int? PromedioFinal { get; set; }

    public string? Estado { get; set; }

    public virtual Curso? FkCursoNavigation { get; set; }

    public virtual Alumno? PkAlumnoNavigation { get; set; }
}

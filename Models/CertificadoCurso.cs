using System;
using System.Collections.Generic;

namespace BACK_FLK.Models;

public partial class CertificadoCurso
{
    public int PkCertificadoCurso { get; set; }

    public int? FkCurso { get; set; }

    public DateOnly? FechaEmision { get; set; }

    public DateOnly? FechaCaducidad { get; set; }

    public virtual Curso? FkCursoNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace BACK_FLK.Models;

public partial class DocenteDisponible
{
    public int PkDocenteDisponibles { get; set; }

    public int? FkUsuario { get; set; }

    public int? FkAsinaturaCertificada { get; set; }

    public DateOnly? FechaEmisionCertificado { get; set; }

    public DateOnly? FechaVencimientoCertificado { get; set; }

    public byte[]? CertificadoPdf { get; set; }

    public virtual ICollection<Curso> CursoFkDocentePracticaNavigations { get; set; } = new List<Curso>();

    public virtual ICollection<Curso> CursoFkDocenteTeoriaNavigations { get; set; } = new List<Curso>();

    public virtual Asignatura? FkAsinaturaCertificadaNavigation { get; set; }

    public virtual Usuario? FkUsuarioNavigation { get; set; }
}

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BACK_FLK.Models;

public partial class DocenteDisponible
{
    public int PkDocenteDisponibles { get; set; }

    public int? FkUsuario { get; set; }

    public int? FkAsinaturaCertificada { get; set; }

    public DateOnly? FechaEmisionCertificado { get; set; }

    public DateOnly? FechaVencimientoCertificado { get; set; }

    public byte[]? CertificadoPdf { get; set; }

    [JsonIgnore]
    public virtual ICollection<Curso> CursoFkDocentePracticaNavigations { get; set; } = new List<Curso>();

    [JsonIgnore]
    public virtual ICollection<Curso> CursoFkDocenteTeoriaNavigations { get; set; } = new List<Curso>();

    [JsonIgnore]
    public virtual Asignatura? FkAsinaturaCertificadaNavigation { get; set; }

    [JsonIgnore]
    public virtual Usuario? FkUsuarioNavigation { get; set; }
}

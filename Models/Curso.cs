using System;
using System.Collections.Generic;

namespace BACK_FLK.Models;

public partial class Curso
{
    public int PkCurso { get; set; }

    public int? FkServicio { get; set; }

    public int? FkDocenteTeoria { get; set; }

    public int? FkDocentePractica { get; set; }

    public int? FkAsinatura { get; set; }

    public string? UbicacionTeoria { get; set; }

    public string? UbicacionPractica { get; set; }

    public DateTime? InicioTeoria { get; set; }

    public DateTime? FinTeoria { get; set; }

    public DateTime? InicioPractica { get; set; }

    public DateTime? FinPractica { get; set; }

    public string? ComentariosIncidencias { get; set; }

    public virtual ICollection<AlumnoXcurso> AlumnoXcursos { get; set; } = new List<AlumnoXcurso>();

    public virtual ICollection<CertificadoCurso> CertificadoCursos { get; set; } = new List<CertificadoCurso>();

    public virtual Asignatura? FkAsinaturaNavigation { get; set; }

    public virtual DocenteDisponible? FkDocentePracticaNavigation { get; set; }

    public virtual DocenteDisponible? FkDocenteTeoriaNavigation { get; set; }

    public virtual Servicio? FkServicioNavigation { get; set; }
}

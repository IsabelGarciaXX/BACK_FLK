using System;
using System.Collections.Generic;

namespace BACK_FLK.Models;

public partial class TipoInspeccion
{
    public int PkTipoInspeccion { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<CertificadoresDisponible> CertificadoresDisponibles { get; set; } = new List<CertificadoresDisponible>();

    public virtual ICollection<Inspeccione> Inspecciones { get; set; } = new List<Inspeccione>();

    public virtual ICollection<InspectoresDisponible> InspectoresDisponibles { get; set; } = new List<InspectoresDisponible>();
}

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BACK_FLK.Models;

public partial class TipoInspeccion
{
    public int PkTipoInspeccion { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    [JsonIgnore]
    public virtual ICollection<CertificadoresDisponible> CertificadoresDisponibles { get; set; } = new List<CertificadoresDisponible>();

    [JsonIgnore]
    public virtual ICollection<Inspeccione> Inspecciones { get; set; } = new List<Inspeccione>();

    [JsonIgnore]
    public virtual ICollection<InspectoresDisponible> InspectoresDisponibles { get; set; } = new List<InspectoresDisponible>();
}

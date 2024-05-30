using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BACK_FLK.Models;

public partial class CertificadoresDisponible
{
    public int PkCertificadoresDisponibles { get; set; }

    public int? FkUsuario { get; set; }

    public int? FkTipoInspeccion { get; set; }

    public DateOnly? FechaEmisionCertificado { get; set; }

    public DateOnly? FechaVencimientoCertificado { get; set; }

    public byte[]? CertificadoPdf { get; set; }

    public byte[]? FirmaYselloDigital { get; set; }

    [JsonIgnore]
    public virtual TipoInspeccion? FkTipoInspeccionNavigation { get; set; }

    [JsonIgnore]
    public virtual Usuario? FkUsuarioNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<Inspeccione> Inspecciones { get; set; } = new List<Inspeccione>();
}

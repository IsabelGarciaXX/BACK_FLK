using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BACK_FLK.Models;

public partial class CertificadoInspeccion
{
    public int PkCertificadoInspeccion { get; set; }

    public int? FkInspeccion { get; set; }

    public DateOnly? FechaEmision { get; set; }

    public DateOnly? FechaCaducidad { get; set; }

    public byte[]? FondoCertificado { get; set; }

    [JsonIgnore]
    public virtual Inspeccione? FkInspeccionNavigation { get; set; }
}

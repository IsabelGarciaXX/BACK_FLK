using System;
using System.Collections.Generic;

namespace BACK_FLK.Models;

public partial class CertificadoInspeccion
{
    public int PkCertificadoInspeccion { get; set; }

    public int? FkInspeccion { get; set; }

    public DateOnly? FechaEmision { get; set; }

    public DateOnly? FechaCaducidad { get; set; }

    public byte[]? FondoCertificado { get; set; }

    public virtual Inspeccione? FkInspeccionNavigation { get; set; }
}

using System;
using System.Collections.Generic;

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

    public virtual TipoInspeccion? FkTipoInspeccionNavigation { get; set; }

    public virtual Usuario? FkUsuarioNavigation { get; set; }

    public virtual ICollection<Inspeccione> Inspecciones { get; set; } = new List<Inspeccione>();
}

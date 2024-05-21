using System;
using System.Collections.Generic;

namespace BACK_FLK.Models;

public partial class Inspeccione
{
    public int PkInspeccion { get; set; }

    public int? FkServicio { get; set; }

    public int? FkEmpresas { get; set; }

    public int? FkCertificadorAsignado { get; set; }

    public int? FkTipoInspeccion { get; set; }

    public int? FkInspectoresAsignados { get; set; }

    public DateOnly? FechaInspeccion { get; set; }

    public string? Ubicacion { get; set; }

    public byte[]? Documentacion { get; set; }

    public string? Estado { get; set; }

    public int? FkVehiculo { get; set; }

    public string? ObservacionesYRecomendaciones { get; set; }

    public virtual ICollection<CertificadoInspeccion> CertificadoInspeccions { get; set; } = new List<CertificadoInspeccion>();

    public virtual CertificadoresDisponible? FkCertificadorAsignadoNavigation { get; set; }

    public virtual Empresa? FkEmpresasNavigation { get; set; }

    public virtual AsignacionInspectore? FkInspectoresAsignadosNavigation { get; set; }

    public virtual Servicio? FkServicioNavigation { get; set; }

    public virtual TipoInspeccion? FkTipoInspeccionNavigation { get; set; }

    public virtual Vehiculo? FkVehiculoNavigation { get; set; }
}

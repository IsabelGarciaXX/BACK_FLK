using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

    public DateTime? FechaHoraInicio { get; set; }
    public DateTime? FechaHoraFinalizacion { get; set; }
    public DateTime? FechaHoraEntrada { get; set; }
    public DateTime? FechaHoraSalida { get; set; }
    public DateTime? FechaHoraRegistroInspeccion { get; set; }

    [JsonIgnore]
    public virtual ICollection<CertificadoInspeccion> CertificadoInspeccions { get; set; } = new List<CertificadoInspeccion>();

    [JsonIgnore]
    public virtual CertificadoresDisponible? FkCertificadorAsignadoNavigation { get; set; }

    [JsonIgnore]
    public virtual Empresa? FkEmpresasNavigation { get; set; }

    [JsonIgnore]
    public virtual AsignacionInspectore? FkInspectoresAsignadosNavigation { get; set; }

    [JsonIgnore]
    public virtual Servicio? FkServicioNavigation { get; set; }

    [JsonIgnore]
    public virtual TipoInspeccion? FkTipoInspeccionNavigation { get; set; }

    [JsonIgnore]
    public virtual Vehiculo? FkVehiculoNavigation { get; set; }
}

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BACK_FLK.Models;

public partial class Vehiculo
{
    public int PkVehiculo { get; set; }

    public string? Fabricante { get; set; }

    public string? Modelo { get; set; }

    public string? NumeroSerie { get; set; }

    //Marca se refiere a Placa, Marca = Placa
    public string? Marca { get; set; }

    public int? FkTipoDeVehiculos { get; set; }

    public int? FkEmpresas { get; set; }
    [JsonIgnore]
    public virtual Empresa? FkEmpresasNavigation { get; set; }
    [JsonIgnore]
    public virtual TipoDeVehiculo? FkTipoDeVehiculosNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<Inspeccione> Inspecciones { get; set; } = new List<Inspeccione>();
}

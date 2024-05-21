using System;
using System.Collections.Generic;

namespace BACK_FLK.Models;

public partial class TipoDeVehiculo
{
    public int PkTipoDeVehiculos { get; set; }

    public string? TipoDeVehiculo1 { get; set; }

    public int? CapacidadCarga { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}

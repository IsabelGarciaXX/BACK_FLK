using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BACK_FLK.Models;

public partial class Empresa
{
    public int PkEmpresas { get; set; }

    public string? Ruc { get; set; }

    public string? Nombre { get; set; }

    public string? RazonSocial { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    [JsonIgnore]
    public virtual ICollection<Inspeccione> Inspecciones { get; set; } = new List<Inspeccione>();

    [JsonIgnore]
    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}

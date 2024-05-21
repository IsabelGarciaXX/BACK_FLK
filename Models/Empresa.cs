using System;
using System.Collections.Generic;

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

    public virtual ICollection<Inspeccione> Inspecciones { get; set; } = new List<Inspeccione>();

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}

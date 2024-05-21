using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BACK_FLK.Models;

public partial class Personal
{
    public int PkPersonal { get; set; }

    public int? FkUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Dni { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    [JsonIgnore]
    public virtual Usuario? FkUsuarioNavigation { get; set; }
}

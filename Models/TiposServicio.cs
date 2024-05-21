using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BACK_FLK.Models;

public partial class TiposServicio
{

    [Key]
    public int PkTiposServicio { get; set; }


    [Required]
    public string? Nombre { get; set; }

    [JsonIgnore]
    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BACK_FLK.Models;

public partial class Usuario
{
    [Key]
    public int PkUsuario { get; set; }
    [Required]
    public string? NombreUsuario { get; set; }
    [Required]
    public string? Contraseña { get; set; }

    [ForeignKey("Rol")]
    public int? FkRol { get; set; }

    [JsonIgnore]
    public virtual ICollection<CertificadoresDisponible> CertificadoresDisponibles { get; set; } = new List<CertificadoresDisponible>();
    [JsonIgnore]
    public virtual ICollection<DocenteDisponible> DocenteDisponibles { get; set; } = new List<DocenteDisponible>();
    [JsonIgnore]
    public virtual Rol? FkRolNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<InspectoresDisponible> InspectoresDisponibles { get; set; } = new List<InspectoresDisponible>();
    [JsonIgnore]
    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BACK_FLK.Models;

public partial class AsignacionInspectore
{
    public int PkAsignacionId { get; set; }

    public int? FkInpectoresDisponibles { get; set; }

    [JsonIgnore]
    public virtual InspectoresDisponible? FkInpectoresDisponiblesNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<Inspeccione> Inspecciones { get; set; } = new List<Inspeccione>();
}

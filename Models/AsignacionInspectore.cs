using System;
using System.Collections.Generic;

namespace BACK_FLK.Models;

public partial class AsignacionInspectore
{
    public int PkAsignacionId { get; set; }

    public int? FkInpectoresDisponibles { get; set; }

    public virtual InspectoresDisponible? FkInpectoresDisponiblesNavigation { get; set; }

    public virtual ICollection<Inspeccione> Inspecciones { get; set; } = new List<Inspeccione>();
}

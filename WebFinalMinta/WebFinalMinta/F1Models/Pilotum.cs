using System;
using System.Collections.Generic;

namespace WebFinalMinta.F1Models;

public partial class Pilotum
{
    public int PilotaId { get; set; }

    public string Nev { get; set; } = null!;

    public string? Nemzetiseg { get; set; }

    public DateTime SzuletesiDatum { get; set; }

    public virtual ICollection<Eredmeny> Eredmenies { get; set; } = new List<Eredmeny>();
}

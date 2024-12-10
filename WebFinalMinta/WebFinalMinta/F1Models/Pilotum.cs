using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebFinalMinta.F1Models;

public partial class Pilotum
{
    public int PilotaId { get; set; }

    public string Nev { get; set; } = null!;

    public string? Nemzetiseg { get; set; }

    public DateTime SzuletesiDatum { get; set; }

    [JsonIgnore]

    public virtual ICollection<Eredmeny> Eredmenies { get; set; } = new List<Eredmeny>();
}

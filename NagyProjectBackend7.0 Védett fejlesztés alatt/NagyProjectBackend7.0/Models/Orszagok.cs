using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NagyProjectBackend7._0.Models;

public partial class Orszagok
{
    public int OrszagId { get; set; }

    public string OrszagKod { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Felhasznalok> Felhasznaloks { get; set; } = new List<Felhasznalok>();
}

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NagyProjectBackend7.Models;

public partial class Varosok
{
    public int VarosId { get; set; }

    public string VarosNev { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Felhasznalok> Felhasznaloks { get; set; } = new List<Felhasznalok>();
}

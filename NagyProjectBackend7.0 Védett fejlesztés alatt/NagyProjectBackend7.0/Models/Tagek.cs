using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NagyProjectBackend7.Models;

public partial class Tagek
{
    public int TagId { get; set; }

    public string TagNev { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Tagkapcsolo> Tagkapcsolos { get; set; } = new List<Tagkapcsolo>();
}

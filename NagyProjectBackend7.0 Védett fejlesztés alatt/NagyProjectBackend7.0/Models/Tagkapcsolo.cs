using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NagyProjectBackend7.Models;

public partial class Tagkapcsolo
{
    public int Id { get; set; }

    public int TagKapcsoloId { get; set; }

    public int TermekTagKapcsoloId { get; set; }

    public virtual Tagek TagKapcsolo { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Termekek> Termekeks { get; set; } = new List<Termekek>();
}

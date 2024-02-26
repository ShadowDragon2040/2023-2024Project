using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NagyProjectBackend7._0.Models;

public partial class Tagkapcsolo
{
    public int Id { get; set; }

    public int TagKapcsoloId { get; set; }

    public int TermekTagKapcsoloId { get; set; }
    [JsonIgnore]
    public virtual Termekek IdNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Tagek TagKapcsolo { get; set; } = null!;
}

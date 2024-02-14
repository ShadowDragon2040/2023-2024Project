using System;
using System.Collections.Generic;

namespace NagyProjectBackend7._0.Models;

public partial class Tagkapcsolo
{
    public int Id { get; set; }

    public int TagKapcsoloId { get; set; }

    public int TermekTagKapcsoloId { get; set; }

    public virtual Tagek TagKapcsolo { get; set; } = null!;
}

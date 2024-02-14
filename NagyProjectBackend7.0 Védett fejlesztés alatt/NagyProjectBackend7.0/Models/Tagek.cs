using System;
using System.Collections.Generic;

namespace NagyProjectBackend7._0.Models;

public partial class Tagek
{
    public int TagId { get; set; }

    public string TagNev { get; set; } = null!;

    public virtual ICollection<Tagkapcsolo> Tagkapcsolos { get; set; } = new List<Tagkapcsolo>();
}

using System;
using System.Collections.Generic;

namespace NagyProjectBackend7.Models;

public partial class Varosok
{
    public int VarosId { get; set; }

    public string VarosNev { get; set; } = null!;

    public virtual ICollection<Felhasznalok> Felhasznaloks { get; set; } = new List<Felhasznalok>();
}

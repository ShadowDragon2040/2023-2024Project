using System;
using System.Collections.Generic;

namespace NagyProjectBackend7.Models;

public partial class Orszagok
{
    public int OrszagId { get; set; }

    public string OrszagKod { get; set; } = null!;

    public virtual ICollection<Felhasznalok> Felhasznaloks { get; set; } = new List<Felhasznalok>();
}

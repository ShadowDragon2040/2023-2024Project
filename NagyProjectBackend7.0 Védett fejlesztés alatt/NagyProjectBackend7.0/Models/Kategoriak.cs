using System;
using System.Collections.Generic;

namespace NagyProjectBackend7._0.Models;

public partial class Kategoriak
{
    public int KategoriaId { get; set; }

    public string KategoriaNev { get; set; } = null!;

    public virtual ICollection<Termekek> Termekeks { get; set; } = new List<Termekek>();
}

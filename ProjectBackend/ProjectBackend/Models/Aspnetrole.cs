using System;
using System.Collections.Generic;

namespace ProjectBackend.Models;

public partial class Aspnetrole
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Aspnetuserrole> Aspnetuserroles { get; set; } = new List<Aspnetuserrole>();
}

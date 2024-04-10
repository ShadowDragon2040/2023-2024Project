﻿using System;
using System.Collections.Generic;

namespace ProjectBackend.Models;

public partial class Aspnetrole
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public virtual ICollection<Aspnetuser> Users { get; set; } = new List<Aspnetuser>();
}
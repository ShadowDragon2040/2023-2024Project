﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace authApi.Models;

public partial class Kategoriak
{
    public int KategoriaId { get; set; }

    public string KategoriaNev { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Termekek> Termekeks { get; set; } = new List<Termekek>();
}

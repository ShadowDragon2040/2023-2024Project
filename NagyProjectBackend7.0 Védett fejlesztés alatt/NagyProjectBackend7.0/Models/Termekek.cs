﻿using System;
using System.Collections.Generic;

namespace NagyProjectBackend7.Models;

public partial class Termekek
{
    public int TermekId { get; set; }

    public string TermekNev { get; set; } = null!;

    public int Ar { get; set; }

    public string Leiras { get; set; } = null!;

    public int Menyiseg { get; set; }

    public int KategoriaId { get; set; }

    public int TagId { get; set; }

    public string Keputvonal { get; set; } = null!;

    public virtual ICollection<Hozzaszolasok> Hozzaszolasoks { get; set; } = new List<Hozzaszolasok>();

    public virtual ICollection<Szamlaza> Szamlazas { get; set; } = new List<Szamlaza>();
}

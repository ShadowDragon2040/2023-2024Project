﻿using System;
using System.Collections.Generic;

namespace NagyProjectBackend7.Models;

public partial class Hozzaszolasok
{
    public int HozzaszolasId { get; set; }

    public int FelhasznaloId { get; set; }

    public int TermekId { get; set; }

    public string Leiras { get; set; } = null!;

    public bool Ertekeles { get; set; }

    public virtual Felhasznalok Felhasznalo { get; set; } = null!;

    public virtual Termekek Termek { get; set; } = null!;
}

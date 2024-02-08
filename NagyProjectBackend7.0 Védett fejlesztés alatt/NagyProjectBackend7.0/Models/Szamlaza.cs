﻿using System;
using System.Collections.Generic;

namespace NagyProjectBackend7.Models;

public partial class Szamlaza
{
    public int SzamlazasId { get; set; }

    public int FelhasznaloId { get; set; }

    public int TermekId { get; set; }

    public int SzinHex { get; set; }

    public DateTime VasarlasIdopontja { get; set; }

    public bool SikeresSzalitas { get; set; }

    public virtual Felhasznalok Felhasznalo { get; set; } = null!;

    public virtual Termekek Termek { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NagyProjectBackend7._0.Models;

public partial class Szamlaza
{
    public int SzamlazasId { get; set; }

    public int FelhasznaloId { get; set; }

    public int TermekId { get; set; }

    public int SzinHex { get; set; }

    public DateTime VasarlasIdopontja { get; set; }

    public bool SikeresSzalitas { get; set; }
    [JsonIgnore]
    public virtual Felhasznalok Felhasznalo { get; set; } = null!;
    [JsonIgnore]
    public virtual Termekek Termek { get; set; } = null!;
}

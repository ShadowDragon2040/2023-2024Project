using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NagyProjectBackend7._0.Models;

public partial class Hozzaszolasok
{
    public int HozzaszolasId { get; set; }

    public int FelhasznaloId { get; set; }

    public int TermekId { get; set; }

    public string Leiras { get; set; } = null!;

    public int Ertekeles { get; set; }
    [JsonIgnore]
    public virtual Felhasznalok Felhasznalo { get; set; } = null!;
    [JsonIgnore]
    public virtual Termekek Termek { get; set; } = null!;
}

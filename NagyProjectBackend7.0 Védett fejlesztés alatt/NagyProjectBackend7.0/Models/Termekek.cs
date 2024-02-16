using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NagyProjectBackend7._0.Models;

public partial class Termekek
{
    public int TermekId { get; set; }

    public string TermekNev { get; set; } = null!;

    public int Ar { get; set; }

    public string Leiras { get; set; } = null!;

    public int Menyiseg { get; set; }

    public int KategoriaId { get; set; }

    public string Keputvonal { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Hozzaszolasok> Hozzaszolasoks { get; set; } = new List<Hozzaszolasok>();
    [JsonIgnore]
    public virtual Kategoriak Kategoria { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Szamlaza> Szamlazas { get; set; } = new List<Szamlaza>();
    [JsonIgnore]
    public virtual Tagkapcsolo? Tagkapcsolo { get; set; }
}

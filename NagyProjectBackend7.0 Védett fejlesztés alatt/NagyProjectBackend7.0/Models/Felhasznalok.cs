using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NagyProjectBackend7._0.Models;

public partial class Felhasznalok
{
    public int FelhasznaloId { get; set; }

    public string LoginNev { get; set; } = null!;

    public string Hash { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string Nev { get; set; } = null!;

    public int Jog { get; set; }

    public string Email { get; set; } = null!;

    public DateTime AktivalasIdopotja { get; set; }

    public string ProfilKep { get; set; } = null!;

    public int OrszagKodId { get; set; }

    public int VarosNevId { get; set; }

    public string UtcaNev { get; set; } = null!;

    public string IranyitoSzam { get; set; } = null!;

    public int Hazszam { get; set; }
    [JsonIgnore]
    public virtual ICollection<Hozzaszolasok> Hozzaszolasoks { get; set; } = new List<Hozzaszolasok>();
    [JsonIgnore]
    public virtual Orszagok OrszagKod { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Szamlaza> Szamlazas { get; set; } = new List<Szamlaza>();
    [JsonIgnore]
    public virtual Varosok VarosNev { get; set; } = null!;
}

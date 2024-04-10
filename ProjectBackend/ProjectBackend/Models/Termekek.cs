using System;
using System.Collections.Generic;

namespace ProjectBackend.Models;

public partial class Termekek
{
    public int TermekId { get; set; }

    public string TermekNev { get; set; } = null!;

    public int Ar { get; set; }

    public string Leiras { get; set; } = null!;

    public int Menyiseg { get; set; }

    public int KategoriaId { get; set; }

    public string Keputvonal { get; set; } = null!;

    public virtual ICollection<Hozzaszolasok> Hozzaszolasoks { get; set; } = new List<Hozzaszolasok>();

    public virtual Kategoriak Kategoria { get; set; } = null!;

    public virtual ICollection<Szamlaza> Szamlazas { get; set; } = new List<Szamlaza>();

    public virtual ICollection<Tagkapcsolo> Tagkapcsolos { get; set; } = new List<Tagkapcsolo>();
}

using System;
using System.Collections.Generic;

namespace ProjectBackend.Models;

public partial class Aspnetuser
{
    public string Id { get; set; } = null!;

    public int EmailCode { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public DateTime AktivalasIdopotja { get; set; }

    public string ProfilKep { get; set; } = null!;

    public virtual Aspnetuserrole? Aspnetuserrole { get; set; }

    public virtual ICollection<Helyadatok> Helyadatoks { get; set; } = new List<Helyadatok>();

    public virtual ICollection<Hozzaszolasok> Hozzaszolasoks { get; set; } = new List<Hozzaszolasok>();

    public virtual ICollection<Szamlaza> Szamlazas { get; set; } = new List<Szamlaza>();
}

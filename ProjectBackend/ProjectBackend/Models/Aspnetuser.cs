using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

    public byte[] ProfilKep { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Helyadatok> Helyadatoks { get; set; } = new List<Helyadatok>();
    [JsonIgnore]
    public virtual ICollection<Hozzaszolasok> Hozzaszolasoks { get; set; } = new List<Hozzaszolasok>();
    [JsonIgnore]
    public virtual ICollection<Szamlaza> Szamlazas { get; set; } = new List<Szamlaza>();
    [JsonIgnore]
    public virtual ICollection<Aspnetrole> Roles { get; set; } = new List<Aspnetrole>();
}

﻿using System;
using System.Collections.Generic;

namespace ProjectBackend.Models;

public partial class Aspnetuser
{
    public string Id { get; set; } = null!;

    public int EmailCode { get; set; }

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public DateTime AktivalasIdopotja { get; set; }

    public byte[] ProfilKep { get; set; } = null!;

    public virtual ICollection<Helyadatok> Helyadatoks { get; set; } = new List<Helyadatok>();

    public virtual ICollection<Hozzaszolasok> Hozzaszolasoks { get; set; } = new List<Hozzaszolasok>();

    public virtual ICollection<Szamlaza> Szamlazas { get; set; } = new List<Szamlaza>();

    public virtual ICollection<Aspnetrole> Roles { get; set; } = new List<Aspnetrole>();
}

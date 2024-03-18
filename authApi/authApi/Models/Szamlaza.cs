using System;
using System.Collections.Generic;

namespace authApi.Models;

public partial class Szamlaza
{
    public int SzamlazasId { get; set; }

    public string UserId { get; set; } = null!;

    public int TermekId { get; set; }

    public int SzinHex { get; set; }

    public DateTime VasarlasIdopontja { get; set; }

    public bool SikeresSzalitas { get; set; }

    public virtual Termekek Termek { get; set; } = null!;

    public virtual Aspnetuser User { get; set; } = null!;
}

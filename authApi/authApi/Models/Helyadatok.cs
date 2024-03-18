using System;
using System.Collections.Generic;

namespace authApi.Models;

public partial class Helyadatok
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string OrszagNev { get; set; } = null!;

    public string VarosNev { get; set; } = null!;

    public string UtcaNev { get; set; } = null!;

    public string Iranyitoszam { get; set; } = null!;

    public string Hazszam { get; set; } = null!;

    public string Egyeb { get; set; } = null!;

    public virtual Aspnetuser User { get; set; } = null!;
}

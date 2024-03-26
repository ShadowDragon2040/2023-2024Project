using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace authApi.Models;

public partial class Hozzaszolasok
{
    public int HozzaszolasId { get; set; }

    public string UserId { get; set; } = null!;

    public int TermekId { get; set; }

    public string Leiras { get; set; } = null!;

    public int Ertekeles { get; set; }
    [JsonIgnore]
    public virtual Termekek? Termek { get; set; }
    [JsonIgnore]
    public virtual Aspnetuser? User { get; set; } 
}

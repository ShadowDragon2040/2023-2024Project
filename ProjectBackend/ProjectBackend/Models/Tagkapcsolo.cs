using System;
using System.Collections.Generic;

namespace ProjectBackend.Models;

public partial class Tagkapcsolo
{
    public int Id { get; set; }

    public int TagekId { get; set; }

    public int TermekekId { get; set; }

    public virtual Tagek Tagek { get; set; } = null!;

    public virtual Termekek Termekek { get; set; } = null!;
}

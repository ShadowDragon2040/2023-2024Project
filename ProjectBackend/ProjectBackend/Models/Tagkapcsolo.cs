using System;
using System.Collections.Generic;

namespace authApi.Models;

public partial class Tagkapcsolo
{
    public int Id { get; set; }

    public int TagKapcsoloId { get; set; }

    public int TermekTagKapcsoloId { get; set; }

    public virtual Termekek IdNavigation { get; set; } = null!;

    public virtual Tagek TagKapcsolo { get; set; } = null!;
}

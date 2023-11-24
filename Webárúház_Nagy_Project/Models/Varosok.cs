using System;
using System.Collections.Generic;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Varosok
    {
        public Varosok()
        {
            Felhasznaloks = new HashSet<Felhasznalok>();
        }

        public int VarosId { get; set; }
        public string VarosNev { get; set; } = null!;

        public virtual ICollection<Felhasznalok> Felhasznaloks { get; set; }
    }
}

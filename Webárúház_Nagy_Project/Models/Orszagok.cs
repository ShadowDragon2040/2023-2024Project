using System;
using System.Collections.Generic;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Orszagok
    {
        public Orszagok()
        {
            Felhasznaloks = new HashSet<Felhasznalok>();
        }

        public int OrszagId { get; set; }
        public string OrszagKod { get; set; } = null!;

        public virtual ICollection<Felhasznalok> Felhasznaloks { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Varosok
    {
        public Varosok()
        {
            Felhasznalok = new HashSet<Felhasznalok>();
        }

        public int VarosId { get; set; }
        public string VarosNev { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Felhasznalok> Felhasznalok { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Orszagok
    {
        public Orszagok()
        {
            Felhasznalok = new HashSet<Felhasznalok>();
        }

        public int OrszagId { get; set; }
        public string OrszagKod { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Felhasznalok> Felhasznalok { get; set; }
    }
}

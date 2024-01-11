using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Termekek
    {
        public Termekek()
        {
            Hozzaszolasok = new HashSet<Hozzaszolasok>();
            Szamlazasok = new HashSet<Szamlazasok>();
        }

        public int TermekekId { get; set; }
        public string TermekNev { get; set; } = null!;
        public int Ar { get; set; }
        public string Leiras { get; set; } = null!;
        public int Menyiseg { get; set; }
        public int SzinId { get; set; }
        public int TagId { get; set; }
        public string Keputvonal { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Hozzaszolasok> Hozzaszolasok { get; set; }
        public virtual ICollection<Szamlazasok> Szamlazasok { get; set; }
    }
}

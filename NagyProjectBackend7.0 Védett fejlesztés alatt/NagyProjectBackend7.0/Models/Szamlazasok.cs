using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Szamlazasok
    {
        public int SzamlazasId { get; set; }
        public int FelhasznaloId { get; set; }
        public int TermekId { get; set; }
        public DateTime VasarlasIdopontja { get; set; }
        public bool SikeresSzalitas { get; set; }

        [JsonIgnore]
        public virtual Felhasznalok Felhasznalok { get; set; } = null!;
        public virtual Termekek Termekek { get; set; } = null!;
    }
}

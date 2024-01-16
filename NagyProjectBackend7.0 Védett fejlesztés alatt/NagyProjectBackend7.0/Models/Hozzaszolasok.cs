using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Hozzaszolasok
    {
        public int HozzaszolasId { get; set; }
        public int FelhasznaloId { get; set; }
        public int TermekId { get; set; }
        public string Leiras { get; set; } = null!;
        public int Ertekeles { get; set; }

        [JsonIgnore]
        public virtual Felhasznalok Felhasznalok { get; set; } = null!;
        public virtual Termekek Termekek { get; set; } = null!;
    }
}

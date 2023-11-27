using System;
using System.Collections.Generic;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Termekek
    {
        public Termekek()
        {
            Hozzaszolasoks = new HashSet<Hozzaszolasok>();
            Szamlazas = new HashSet<Szamlaza>();
        }

        public Guid Id { get; set; }
        public string TermekNev { get; set; } = null!;
        public int Ar { get; set; }
        public string Leiras { get; set; } = null!;
        public int Menyiseg { get; set; }
        public int SzinId { get; set; }
        public int TagId { get; set; }
        public string Keputvonal { get; set; } = null!;

        public virtual ICollection<Hozzaszolasok> Hozzaszolasoks { get; set; }
        public virtual ICollection<Szamlaza> Szamlazas { get; set; }
    }
}

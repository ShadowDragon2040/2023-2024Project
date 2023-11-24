using System;
using System.Collections.Generic;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Termekek
    {
        public Termekek()
        {
            Hozzaszolas = new HashSet<Hozzaszolas>();
            Szamlazas = new HashSet<Szamlazas>();
        }

        public Guid Id { get; set; }
        public string TermekNev { get; set; } = null!;
        public int Ar { get; set; }
        public string Leiras { get; set; } = null!;
        public int Menyiseg { get; set; }
        public int SzinId { get; set; }
        public int TagId { get; set; }
        public string Keputvonal { get; set; } = null!;

        public virtual Szinek Szin { get; set; } = null!;
        public virtual Tagek Tag { get; set; } = null!;
        public virtual ICollection<Hozzaszolas> Hozzaszolas { get; set; }
        public virtual ICollection<Szamlazas> Szamlazas { get; set; }
    }
}

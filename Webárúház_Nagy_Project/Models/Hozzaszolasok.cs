using System;
using System.Collections.Generic;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Hozzaszolasok
    {
        public int Id { get; set; }
        public Guid FelhasznaloId { get; set; }
        public Guid TermekId { get; set; }
        public string Leiras { get; set; } = null!;
        public bool Ertekeles { get; set; }

        public virtual Felhasznalok Felhasznalo { get; set; } = null!;
        public virtual Termekek Termek { get; set; } = null!;
    }
}

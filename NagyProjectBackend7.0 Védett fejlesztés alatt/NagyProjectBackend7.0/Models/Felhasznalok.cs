﻿using System;
using System.Collections.Generic;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Felhasznalok
    {
        public Felhasznalok()
        {
            Hozzaszolasok = new HashSet<Hozzaszolasok>();
            Szamlazasok = new HashSet<Szamlazasok>();
        }

        public int FelhasznaloId { get; set; }
        public string LoginNev { get; set; } = null!;
        public string Hash { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public string Nev { get; set; } = null!;
        public int Jog { get; set; }
        public bool Aktivalva { get; set; }
        public string Email { get; set; } = null!;
        public string ProfilKep { get; set; } = null!;
        public int OrszagKodId { get; set; }
        public int VarosNevId { get; set; }
        public string UtcaNev { get; set; } = null!;
        public string IranyitoSzam { get; set; } = null!;
        public int Hazszam { get; set; }

        public virtual Orszagok OrszagKod { get; set; } = null!;
        public virtual Varosok VarosNev { get; set; } = null!;
        public virtual ICollection<Hozzaszolasok> Hozzaszolasok { get; set; }
        public virtual ICollection<Szamlazasok> Szamlazasok { get; set; }
    }
}

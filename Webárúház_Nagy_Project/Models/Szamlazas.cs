using System;
using System.Collections.Generic;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Szamlazas
    {
        public int Id { get; set; }
        public Guid FelhasznaloId { get; set; }
        public Guid TermekId { get; set; }
        public DateTime VasarlasIdopontja { get; set; }
        public bool SikeresSzalitas { get; set; }

        public virtual Felhasznalok Felhasznalo { get; set; } = null!;
        public virtual Termekek Termek { get; set; } = null!;
    }
}

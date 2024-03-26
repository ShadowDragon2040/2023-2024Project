using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdatKarbantarto.Model
{
    public class Szamla
    {
        public int SzamlazasId { get; set; }

        public string UserId { get; set; } = null!;

        public int TermekId { get; set; }

        public int SzinHex { get; set; }

        public DateTime VasarlasIdopontja { get; set; }
        public bool SikeresSzalitas { get; set; }


    }
}

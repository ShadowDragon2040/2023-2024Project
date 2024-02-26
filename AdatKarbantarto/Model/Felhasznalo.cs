using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdatKarbantarto.Model
{
    public class Felhasznalo
    {
        public int FelhasznaloId { get; set; }
        public string LoginNev { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public string Nev { get; set; }
        public int Jog { get; set; }
        public bool Aktivalva { get; set; }
        public string Email { get; set; }
        public string ProfilKep { get; set; }
        public int OrszagKodId { get; set; }
        public int VarosNevId { get; set; }
        public string UtcaNev { get; set; }
        public string IranyitoSzam { get; set; }
        public int Hazszam { get; set; }
      
    }
}

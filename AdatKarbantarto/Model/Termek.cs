using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdatKarbantarto.Model
{
    public class Termek
    {
        public int termekId {  get; set; }
        public string termekNev { get; set; }
        public int ar {  get; set; }
        public string leiras { get; set; }
        public int menyiseg { get; set; }
        public int kategoriaId { get; set; }
        public string kepUtvonal{ get; set; }
    }
}

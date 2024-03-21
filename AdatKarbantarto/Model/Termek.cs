using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdatKarbantarto.Model
{
    public class Termek
    {
        public int TermekId {  get; set; }
        public string TermekNev { get; set; }
        public int Ar {  get; set; }
        public string Leiras { get; set; }
        public int Menyiseg { get; set; }
        public int KategoriaId { get; set; }
        public string KepUtvonal{ get; set; }

        public override string? ToString()
        {
            return $"ID:{TermekId}";
        }
    }
}

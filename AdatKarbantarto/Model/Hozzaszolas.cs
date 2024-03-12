using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdatKarbantarto.Model
{
    public class Hozzaszolas
    {
        public int hozzaszolasId {  get; set; }
        public int FelhasznaloId { get; set; }
        public int TermekId { get; set; }
        public string Leiras {  get; set; }
        public int Ertekeles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdatKarbantarto.Model
{
    public class Hozzaszolas
    {
        public int HozzaszolasId { get; set; }
        public string UserId { get; set; } = null!;
        public int TermekId { get; set; }
        public string Leiras { get; set; } = null!;

        public int Ertekeles { get; set; }
    }
}

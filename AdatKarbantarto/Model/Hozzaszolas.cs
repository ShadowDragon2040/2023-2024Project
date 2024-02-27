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
        public int felhasznaloId { get; set; }
        public int termekId { get; set; }
        public string leiras {  get; set; }
        public int ertekeles { get; set; }
    }
}

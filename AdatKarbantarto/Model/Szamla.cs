using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdatKarbantarto.Model
{
    public class Szamla
    {
        public int szamlazasId {  get; set; }
        public string felhasznaloId {  get; set; }
        public int termekId {  get; set; }
        public int szinHex {  get; set; }
        public string vasarlasIdopontja {  get; set; }
        public bool sikeresSzallitas {  get; set; }
    }
}

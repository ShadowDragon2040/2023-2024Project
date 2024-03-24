using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdatKarbantarto.Model
{
    public class FtpFile
    {
        public int id;
        public string file;
        public DateTime timestamp;

        public override string? ToString()
        {
            return file+".png";
        }
    }
}

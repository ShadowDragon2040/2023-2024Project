using System;
using System.Collections.Generic;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Tagek
    {
        public Tagek()
        {
            Tagkapcsolos = new HashSet<Tagkapcsolo>();
        }

        public int TagId { get; set; }
        public string TagNev { get; set; } = null!;

        public virtual ICollection<Tagkapcsolo> Tagkapcsolos { get; set; }
    }
}

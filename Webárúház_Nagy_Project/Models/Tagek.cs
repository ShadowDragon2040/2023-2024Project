using System;
using System.Collections.Generic;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Tagek
    {
        public Tagek()
        {
            Termekeks = new HashSet<Termekek>();
        }

        public int TagId { get; set; }
        public string TagNev { get; set; } = null!;

        public virtual ICollection<Termekek> Termekeks { get; set; }
    }
}

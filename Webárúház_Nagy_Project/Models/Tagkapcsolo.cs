using System;
using System.Collections.Generic;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Tagkapcsolo
    {
        public int Id { get; set; }
        public int TagKapcsoloId { get; set; }
        public int TermekTagKapcsoloId { get; set; }

        public virtual Tagek TagKapcsolo { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Szinek
    {
        public Szinek()
        {
            Szinkapcsolos = new HashSet<Szinkapcsolo>();
        }

        public int SzinId { get; set; }
        public string SzinHex { get; set; } = null!;

        public virtual ICollection<Szinkapcsolo> Szinkapcsolos { get; set; }
    }
}

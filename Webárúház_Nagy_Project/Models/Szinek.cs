using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Szinek
    {
        public Szinek()
        {
            Szinkapcsolo = new HashSet<Szinkapcsolo>();
        }

        public int SzinId { get; set; }
        public string SzinHex { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Szinkapcsolo> Szinkapcsolo { get; set; }
    }
}

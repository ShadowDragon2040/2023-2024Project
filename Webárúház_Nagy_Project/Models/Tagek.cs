using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Webárúház_Nagy_Project.Models
{
    public partial class Tagek
    {
        public Tagek()
        {
            Tagkapcsolo = new HashSet<Tagkapcsolo>();
        }

        public int TagId { get; set; }
        public string TagNev { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Tagkapcsolo> Tagkapcsolo { get; set; }
    }
}
